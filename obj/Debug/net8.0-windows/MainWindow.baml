   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ 
MainWindow��5	   	   $	��720��6   $
��1280��6)   ���	#FF2F2F2F � 	Resources 5       �� 
TargetType �� 	Resources �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 ��Name J� SnapsToDevicePixels �� Triggers��%�  '��       '�� �     'G� 4    �� 5   
   " ��6    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 5��65   5      5      5      �� 5   
   " ��6    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 5��65   5      5      5      �� 5   
   " G�6    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 5��65   5      5      .�5       ��  � �� 5!      �� 5"      " G�6&   .R�5#      �� $ border��6!   $	 5��61   #��z��6B   #��z��6n   #��z��6�   ._�5$      �� $
 PART_ContentHost��6+   # z 6E   5%       5&      5)      5+      5,      5-      .��5.      � $��720.04��6   .+�5/   
   �� $��Center=�6   $��81��61   ���	#FF3E3B3B$	��Top=�6P   $
��1280��6h   
���   �6u   �� 50   
   -   5         ��Name$ Username��50       �� TextWrapping$
 Wrap=�6$   $��490,226,490,0q�68   $	��Top=�6O   $��50��6�   $��Corbel)�6�   $��36(�6�   �� 51   
   $��Username��6   $��574,170,580,0q�6#   $	��Top=�6:   $��Bahnschrift)�6R   
�������$��20(�6~   $��32��6�   $	��300��6�   �� 52   
   $��Password��6   $��582,298,578,0q�6#   $	��Top=�6:   $��Bahnschrift)�6R   $��20(�6k   
�������$��32��6�   $	��300��6�   �� 53   
   $��Dosis)�6   $��HealthTracker��6#   $��	48,13,0,0q�6;   $	��Top=�6N   
�������$��36(�6y   $
��Left=�6�   G� 54   
   -   5         G�Name$ Password��54      $��490,360,490,310q�6(    G� Password$  ��6A    J� RenderTransformOrigin$ 0.5,0.5&�6M   $��50��6m   $��Corbel)�6y   $��36(�6�   �� 55   
   -   5         ��Name$ LoginSubmit��55      $��Login��6&   $��500,470,500,0q�66   $	��Top=�6M   $ 0.5,0.5&�6e   $��32��6�   �� 56   
   -   5        $ Register��56      $��Register��6#   $��500,539,500,149q�66   $��32��6d   �� 57   
   -   5         ��Name$ error��57      $	��400��6   $��50��6+   $��	0,500,0,0q�67   
�������$��22(�6]   $��Center=�6k   58      59      