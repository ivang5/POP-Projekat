   M S B A M L   `   `   `  ����F  BAerodromWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AerodromWPFAerodromWPF  5   	        AerodromWPF.AddNEditWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AerodromWPF     5   	     � Title$  AddNEditWindow��5   	   $	��800��6    $	��550��6-   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFEACE21��6    � Offset$ 0Q�61   � 5      $ 	#FFD12C2C��6   $ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      $	��200 �6   6-   �� 5      $	��200 �6   6-    � RowDefinitions 5   
   �� 5      $	��200 �6   6+   �� 5      $	��200 �6   6+   �� 5      $	��200 �6   6+   �� 5      $	��200 �6   6+   .+�5   
   �� -   5        $��LblSifra��5      $��Sifra:��6    $��0��61   $��0��6A   $��20(�6N   $��Right=�6\   $��	0,44,0,66q�6x   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5        $��TxtSifra��5      $��1��6"   $��0��62   ���	#FFE8D0D0$��	0,44,0,66q�6r   ��6?   ��  �� Path$ Sifra�6r   �� 5   
   -   5        $��LblNaziv��5      $��Naziv:��6    $��0��61   $��1��6A   $��20(�6N   $��Right=�6\   $��	0,44,0,66q�6x   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5        $��TxtNaziv��5      $��1��6"   $��1��62   ���	#FFE8D0D0$��	0,44,0,66q�6r   ��6?   �� $ Naziv�6�   �� 5!   
   -   5        $��LblGrad��5!      $��Grad:��6   $��0��6/   $��2��6?   $��20(�6L   $��Right=�6Z   $��	0,44,0,66q�6v   $
��Bold"�6�   $��Italic$�6�   �� 5"   
   -   5        $��TxtGrad��5"      $��1��6!   $��2��61   ���	#FFE8D0D0$��	0,44,0,66q�6p   ��6>   �� $
 Grad�6�   �� 5$   
   -   5        $��Sacuvaj��5$      $��Sacuvaj��6    $��3��6H   $��0��6U   $��93,55,160,75q�6f   $��2��6|   ���	#FFEED47E J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&      	   Opacity$		 0.7Q�6#   5(      �� 5)   
   -   5        $��Odustani��5)      $��Odustani��6!   $��3��6K   $��1��6X   $��100,55,-49,75q�6i   ���	#FFEED47E 5*        5+      $		 0.7Q�6#   5-      5.      5/      