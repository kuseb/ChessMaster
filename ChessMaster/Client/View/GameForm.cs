using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;

namespace Client
{
    public partial class GameForm : Form
    {
        public static GameForm Instance;

        private GlRenderer _glRenderer;
        private Timer _timer;

        private int _lastTouchX, _lastTouchY;

        private bool _rightMouseButtonPressed;
        private bool _leftMouseButtonPressed;

        public GameForm()
        {
            InitializeComponent();
            Instance = this;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            _glRenderer = new GlRenderer();
            _glRenderer.InitializeGl(glControl.Width, glControl.Height);

            _timer = new Timer();
            _timer.Enabled = true;
            _timer.Interval = 1;
            _timer.Tick += timer_Tick;

            glControl.MouseWheel += glControl_MouseWheel;
        }

        void glControl_MouseWheel(object sender, MouseEventArgs e)
        {
            float wheel = -e.Delta;
            _glRenderer.ActiveCamera.Zoom(wheel);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            glControl.Invalidate();
        }

        private void glControl_Paint_1(object sender, PaintEventArgs e)
        {
            _glRenderer.Render();
            glControl.SwapBuffers();
        }

        private void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            var touchX = e.X;
            var touchY = glControl.Height - e.Y;

            float deltaX = touchX - _lastTouchX;
            float deltaY = touchY - _lastTouchY;

            Cursor = Cursors.Hand;

            if (_rightMouseButtonPressed)
            {
                _glRenderer.ActiveCamera.MoveCameraWithTargetInItsLocalAxes(-deltaX, -deltaY, 0);
            }
            else if (_leftMouseButtonPressed)
            {
                float rotationAroundXAxis = (float)(deltaY / glControl.Height * Math.PI);
                float rotationAroundYAxis = (float)(deltaX / glControl.Width * Math.PI);
                _glRenderer.ActiveCamera.RotateAroundTarget(rotationAroundXAxis, rotationAroundYAxis, 0);
            }

            _lastTouchX = touchX;
            _lastTouchY = touchY;
        }

        private void glControl_MouseDown(object sender, MouseEventArgs e)
        {
            var touchX = e.X;
            var touchY = glControl.Height - e.Y;

            if (e.Button == MouseButtons.Left)
                _leftMouseButtonPressed = true;
            else if (e.Button == MouseButtons.Right)
                _rightMouseButtonPressed = true;
        }

        private void glControl_MouseUp(object sender, MouseEventArgs e)
        {
            _leftMouseButtonPressed = false;
            _rightMouseButtonPressed = false;
        }

        private void glControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
