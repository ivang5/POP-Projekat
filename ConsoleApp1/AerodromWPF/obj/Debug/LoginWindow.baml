   M S B A M L   `   `   `  ����F  BAerodromWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AerodromWPFAerodromWPF  5   	       AerodromWPF.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AerodromWPF     5   	     � Title$  Login��5   	   $	��450��6   $	��800��6$   
�������.��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W   .��5      �  � Color$ 	#FFD12C2C��6    � Offset$ 1Q�61   � 5      $ 	#FFEACE21��6   5       � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   .+�5   
   �� -   5        $��	LblOpcije��5      $��Center=�6!   $��0��6>   $��176,46,606,55q�6K   $��2��6b   6u   �� 5   
   -   5        $��LblKorisnickoIme��5      $��Korisnicko ime:��6(   $��0��6B   $��14(�6R   $��Right=�6`   $��0,21,647,50q�6|   $	��114��6�   $��1��6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5        $��TxtKorisnickoIme��5      $��145,21,516,55q�6N   ���	#FFE8D0D0$��1��6|   ��6*   ��  �� Path$ KorisnickoIme�6|   �� 5   
   -   5        $��
LblLozinka��5      $��Lozinka:��6"   $��0��65   $��1��6E   $��14(�6R   $��Right=�6`   $��0,51,652,10q�6|   $��65��6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5        $��
TxtLoznika��5      $��145,51,516,25q�6B   $��1��6Y   ���	#FFE8D0D0��6$   �� $ Lozinka�6f   �� 5   
   -   5        $��BtnLogin��5      $��Login��6!   $��55��61   $
��Left=�6=   $��1��6o   $��221,92,0,-14q�6|   ���	#FFEED47E J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   Opacity$		 0.7Q�6#   5       �� 5!   
   -   5        $��BtnRegistracija��5!      $��Registracija��6(   $��74��6?   $
��Left=�6J   $��1��6�   $��158,223,0,-146q�6�   ���	#FFEED47E 5"        5#      $		 0.7Q�6#   5%      �� 5&   
   -   5        $��	BtnLetovi��5&      $��Letovi��6"   $	��130��63   $
��Left=�6?   $��1��6r   $��545,15,0,61q�6   ���	#FFEED47E 5'        5(      $		 0.7Q�6#   5*      �� 5,   
   $��Ulogujte se:��6   $
��Left=�6'   $��33��6B   $��
108,68,0,0q�6N   $��16(�6b   $	��Top=�6p   $	��179��6�   $
��Bold"�6�   $��Italic$�6�   �� 5-   
   $��Jos uvek nemate nalog?��6   $
��Left=�61   $��33��6L   $��108,185,0,-117q�6X   $��1��6p   $��16(�6}   $	��Top=�6�   $	��188��6�   $
��Bold"�6�   $��Italic$�6�   �� 5.   
   $,��&Pogledajte listu letova bez logovanja!��6   $
��Left=�6A   $��33��6\   $��
459,68,0,0q�6h   $��16(�6|   $	��Top=�6�   $	��299��6�   $
��Bold"�6�   $��Italic$�6�   5/      50      