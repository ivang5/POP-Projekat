   M S B A M L   `   `   `  ����F  BAerodromWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AerodromWPFAerodromWPF  5   	   %    AerodromWPF.AviokompanijeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AerodromWPF     5   	     � Title$  Aviokompanije��5   	   $	��550��6   $	��900��6,   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFEACE21��6    � Offset$ 0Q�61   � 5      $ 	#FFD12C2C��6   $ 0.996Q�61   5       � ColumnDefinitions 5   
   �� 5      $	��700 �6   6-    � RowDefinitions 5   
   �� 5      $	��400 �6   6+   �� 5      $	��100 �6   6+   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DGAviokompanije��5   @      AutoGenerateColumns .    
IsReadOnly . $��0��6W   $��12,0,-171,0q�6d   ���	#FFE8D0D06�   �� 5   
   -   5        $��	btnDelete��5      $��Obriši��6"   $��50��63   $
��Left=�6?   $��Bottom=�6Z   $	��100��6u   $��1��6�   $��
327,0,0,28q�6�   ���	#FFEED47E	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   Opacity$	
 0.7Q�6#   5      �� 5   
   -   5        $��btnClose��5      $��Zatvori��6!   $��50��63   $��Right=�6?   $��Bottom=�6[   $	��100��6v   $��1��6�   $��0,0,-171,28q�6�   ���	#FFEED47E	 5         5!      $	
 0.7Q�6#   5#      �� 5$   
   -   5        $��btnAdd��5$      $��Dodaj��6   $��50��6/   $
��Left=�6;   $��Bottom=�6V   $	��100��6q   $��1��6�   $��
222,0,0,28q�6�   ���	#FFEED47E	 5%        5&      $	
 0.7Q�6#   5(      �� 5)   
   -   5        $��	btnUpdate��5)      $��Izmeni��6"   $��50��63   $
��Left=�6?   $��Bottom=�6Z   $	��100��6u   $��1��6�   $��
117,0,0,28q�6�   ���	#FFEED47E	 5*        5+      $	
 0.7Q�6#   5-      �� 5.   
   -   5        $��	btnLetovi��5.      $��Prikazi Letove��6"   $��50��6;   $
��Left=�6G   $��Bottom=�6b   $	��100��6}   $��1��6�   $��	12,0,0,28q�6�   ���	#FFEED47E	 5/        50      $	
 0.7Q�6#   52      53      54      