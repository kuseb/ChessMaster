   M S B A M L   `   `   `  ����J  FGameViewControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GameViewControlGameViewControl  5   	        GameViewControl.GameWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:GameViewControl     5   	   \ XHelixToolkit.Wpf, Version=2015.1.715.0, Culture=neutral, PublicKeyToken=52aa3500039caf0d$hhttp://helix-toolkit.org/wpf  5   	     � Title$  
GameWindow��5	   	   $��509.189��6   $��514.054��6-    � WindowState$ 	Maximized=�6=   $��Comic Sans MS)�5
   	   $��16(�6$   $��Normal$�62   $
��Bold"�6E    � 	Resources 5       	  style �� 
TargetType �� Property �� Value �� 
StartPoint �� EndPoint � Color	 � Offset  bottomStyle��%  &	        &	 �     �� 5   
   " �6   .�5      ��  � �� 5      �� 5      $	 0,0&�6*   $	 1,1&�6;   .��5      � $ 
DarkOrange��6'   $	 0Q�6:   6G   � 5      $ DarkBlue��6'   $	 1Q�68   6E   5      5      5      �� 5   
   bottomStyle��" ��69   .�5      ��  �@J�Opacity$	 0.5Q�6(   66   �� 5       � ��$ 10q�6'   64   �� 5       � ��$ Normal"�6+   6<   �� 5       � ��$ Stretch=�64   6F   �� 5       � ��$ Stretch=�62   6D   5      5      .��5!      � #��[  6   
 � RowDefinitions
 5"   
   �� 5#      $��* �6   �� 5$      $	��150 �6    � ColumnDefinitions 5&   
   �� 5'      $
��Auto �6   6.   �� 5(      $��* �6   6+   �� 5)      $
��Auto �6   6.   .+�5,   
   &   HelixToolkit.Wpf.HelixViewport3D  $��1��6   $��0��6,      Children. 5-      $  HelixToolkit.Wpf.DefaultLights  g� 5/      -   5        	chess��5/      50      �� 52   
   -   5         ��Name$ leftStackPanel��52      $��0��6-   $��0��6:   $��10q�6J   .+�53      �� -   5         ��Name$ player1TimeLabel��53   1   $��Center=�6   .��6K   
00:00:006U   �� 54      $��Center=�6   $��Images/avatar.png��61   6N   �� 55      -   5        $ player1Nick��55      .��6)   Nick:60   �� 56      .��6   	Winner: 06   �� 57      .��6   	Rank: 06   �� 58      .��6   	Points: 06   59      �� 5;   
   $��0��6   $��2��6"   $��10q�62   $��Right=�6>   .+�5<      �� -   5        $ player2TimeLabel��5<   1   $��Center=�6   .��6K   
00:00:006U   �� 5=      $��Center=�6   $��Images/avatar.png��62   6O   �� 5>      -   5        $ player2Nick��5>      .��6)   Nick:60   �� 5?      .��6   	Winner: 06   �� 5@      .��6   	Rank: 06   �� 5A      .��6   	Points: 06   5B      �� 5D   
   -   5         ��Name$ 	UserMoves��5D      #��[ 6%   $
��Left=�6J   $��1��6e   $��0��6r   $	��100��6�   $��Visible=�6�   �� 5E   
   -   5        $ OpponentMoves��5E      #��[ 6*   $��1��6O   $��2��6\   $��Right=�6l   $	��100��6�   $��Visible=�6�   � 5H   
   $��1��6   $��1��6    5I      �� 5J      $��2* �6#   60   �� 5K      $��* �6#   6/   
 5M      �� 5N      $��* �6    6-   �� 5O      $
��Auto �6    60   .+�5R      �� -	   5        $
 Chat��5R      #��[ 6%   $	��100��6J   $��0��6W   $��0��6d   $��2��6t   �� 5S      -
   5         ��Name$ Message��5S      #��[ 6(   $��0��6M   $��1��6]   6l   �� 5T      -   5         ��Name$ 
SendButton��5T      #��[ 6*   $��1��6O   $��1��6_   .��6�   Send6�   5U      5W      5X      