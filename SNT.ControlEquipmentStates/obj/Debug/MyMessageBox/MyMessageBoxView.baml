   M S B A M L   `   `   `  ����U  QSNT.ControlEquipmentStates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SNT.ControlEquipmentStatesSNT.ControlEquipmentStates  5   	   1    +SNT.ControlEquipmentStates.MyMessageBoxView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:SNT.ControlEquipmentStates     5   	   $	��130��5   	   $	��300��6   ���	#FFB4B4B4  � WindowStartupLocation$  Manual=�69   
 � Top$	 347��6X    � Left$	 539��6b    � 
ResizeMode$ NoResize=�6m    � 	Resources 5	       �� 
TargetType �� Property �� Value��%R   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 20(�6)   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � 	 � ColumnDefinitions	 5      �� 5      -   5        
 ��Name$
 GridForIcon��5   .   $��70 �6#   6.   �� 5      .+�5      �� $��2��6   ���	#FFD0D0D06)   �� 5      -   5         ��Name$
 icon��5      $��5,0,0,0q�6"   �� 5      -   5         ��Name$ MessageText��5   &   $��1��6   $
��Text��6;   $��0q�6t   
���   �$��15(�6�   $��0,5,5,5q�6�    �� TextWrapping$
 Wrap=�6�    �� TextAlignment$ Center=�6�   $��Center=�6�    �� SelectionBrush
 �   ���6G   Z� ��6^   Z� 6   5      �� 5   
   -   5         ��Name$ btnYes��5      $��1��6!   $
��Да��6.   $y�Hidden=�6;   $��Center=�6O   
 J� Uid$ 1��6   $��15(�6�   $��0,5,70,5q�6�   $��50��6�   �� 5   
   -   5        $ btnOk��5      $��1��6    $
��ОК��6-   $y�Hidden=�6:   $��Center=�6N   $ 2��6~   $��15(�6�   $��Center=�6�   $	��0,5q�6�   $��50��6�   �� 5   
   -   5        $ btnNo��5      $��1��6    $��Нет��6-   $y�Hidden=�6;   $��Center=�6O   $ 3��6   $��15(�6�   $��70,5,0,5q�6�   $��50��6�   5+      5,      