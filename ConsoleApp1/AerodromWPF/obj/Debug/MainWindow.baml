   M S B A M L   `   `   `  ����F  BAerodromWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AerodromWPFAerodromWPF  5   	       AerodromWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AerodromWPF     5   	     � Title$  Pocetna strana��5   	   $	��500��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFEACE21��6    � Offset$ 0Q�61   � 5      $ 	#FFD12C2C��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   .+�5   
   �� -   5        $��	LblOpcije��5      $��Center=�6!   $��0��6>   6M   �� 5   
   -   5        $��BtnAerodromi��5      $��	Aerodromi��6%   $	��100��69   $
��Left=�6F   $��1��6|   $��202,64,0,-13q�6�   ���	#FFEED47E J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$	 0.7Q�6#   5      �� 5   
   -   5        $��	BtnLetovi��5      $��Letovi��6"   $	��100��63   $
��Left=�6?   $��1��6r   $��164,174,0,-123q�6   ���	#FFEED47E 5        5      $	 0.7Q�6#   5       �� 5!   
   -   5        $��BtnKorisnici��5!      $��	Korisnici��6%   $	��100��69   $
��Left=�6E   $��1��6{   $��61,64,0,-13q�6�   ���	#FFEED47E 5"        5#      $	 0.7Q�6#   5%      �� 5&   
   -   5        $��BtnAviokompanije��5&      $��Aviokompanije��6)   $	��100��6A   $
��Left=�6M   $��1��6�   $��342,64,0,-13q�6�   ���	#FFEED47E 5'        5(      $	 0.7Q�6#   5*      �� 5+   
   -   5        $��	BtnAvioni��5+      $��Avioni��6"   $	��100��63   $
��Left=�6?   $��1��6r   $��488,64,0,-13q�6   ���	#FFEED47E 5,        5-      $	 0.7Q�6#   5/      �� 50   
   -   5        $��BtnKarte��50      $��Karte��6!   $	��100��61   $
��Left=�6=   $��1��6o   $��391,174,0,-123q�6|   ���	#FFEED47E 51        52      $	 0.7Q�6#   54      �� 55   
   -   5        $��btnClose��55      $��	Odjavi se��6!   $��50��65   $��Right=�6A   $��Bottom=�6]   $	��100��6x   $��1��6�   $��0,0,10,-257q�6�   ���	#FFEED47E 56        57      $	 0.7Q�6#   59      �� 5:   
   $��Izaberite entitet:��6   $
��Left=�6-   $��60��6H   $��
194,72,0,0q�6T   $��36(�6h   $	��Top=�6v   $	��310��6�   $��2��6�   $
��Bold"�6�   $��Italic$�6�   5;      5<      