   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Home   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$
 Home��5	   	   $	��720��6   $
��1280��6#   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��350 �6   �� 5      $	��640 �6   .+�5   
   �� $��81��6   ���	#FF3E3B3B$	��Top=�63   
���   �$��2��6X   $��
0,0,-290,0q�6l   �� 5   
   $��Dosis)�6   $��HealthTracker��6#   $��	48,13,0,0q�6;   $	��Top=�6N   
�������$��36(�6y   $
��Left=�6�   �� 5   
   $
��Home��6   $��Dosis)�6    $��296,21,617,0q�63   $	��Top=�6I   $��28(�6a   ���	#FFC7B2B2$��2��6�   ��6p   Z� ��6�   Z� 6�   �� 5   
   -   5        $��Account��5      $��	50,21,0,0q�6$   $��Dosis)�67   $��28(�6J   $
��Left=�6X   $	��Top=�6t   
�������$��1��6�   $	��102��6�   ��6�   Z� ��6�   Z� 6�   �� 5   
   $��	0,0,0,150q�6   $��0��6(   $	��200��68   $	��300��6E   .+�5      �� $"��Current Caloric intake today��6   $��20(�6;   
���   �$��Bahnschrift)�6\   �� 5      -   5         ��Name$ Current_calories��5      $��Current Calories��6.   $��26(�6I   
���   �6W   �� 5      $ ��Goal  Caloric intake today��6   $��20(�69   
���   �$��Bahnschrift)�6Z   �� 5      -   5        $ Goal_Intake��5      $��Current Caloric intake��6)   $��26(�6J   
���   �6X   5      �� 5   
   $��1��6   $��64,102,-224,0q�6%   $	��550��6<   $	��Top=�6I   .+�5      �� $��30��6   ��6"   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      -   5        $	��250��5      ��6#   �� *FilteredItems+��5      �� 5      .R�5      �� .+�5      �� $
��Bold"�6>   ��6(   �� *Name+6>   �� 5       ��6(   �� *Description+5!      5"      5$      �� 5%      $��Current meals ate today��6   $��30(�66   $��Dosis)�6D   �� 5&      -   5         ��Name$ CurrentMeals��5&      $	��170��6�   ��5'      �� 5(      .R�5)      �� .+�5*      �� �� 5+   "   $�Today you have ate��6&   $
��Bold"�6@    �� 5,   "   $
��Bold"�6<   �6&   �� *Name+6<   5-      �� 5.      �� 5/   "   �6&   �� *
Calories+ �� 50   "   $
�cals��6&   51      52      53      55      56      57      58      