#version 330

uniform mat4 u_MVPMatrix;
uniform mat4 u_model;
uniform mat4 u_cameraView;

in vec3 i_position;
in vec3 i_normal;
in vec4 i_color;

out vec3 o_pos;
out vec3 o_norm;
out vec4 o_color;
 
void main(void)
{
	gl_Position = u_MVPMatrix * vec4(i_position, 1.0);
    o_pos = i_position;
    o_norm = i_normal;
	o_color = i_color;
}