   M S B A M L   `   `   `  ����F  BAerodromWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AerodromWPFAerodromWPF  5   	   "    AerodromWPF.MainPutnikWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AerodromWPF     5   	     � Title$  Pocetna strana��5   	   $	��500��6    $	��800��6-   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFD12C2C��6    � Offset$ 1Q�61   � 5      $ 	#FFEACE21��6   5       � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   .+�5   
   �� -   5        $��	LblOpcije��5      $��Center=�6!   $��0��6>   $��460,-2,322,2q�6K   6c   �� 5   
   $-��'Pogledajte listu svih dostupnih letova!��6   $
��Left=�6B   $��44��6]   $��	84,33,0,0q�6i   $��25(�6|   $	��Top=�6�   $	��462��6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5        $��	BtnLetovi��5      $��Letovi��6"   $	��117��63   $
��Left=�6?   $��239,82,0,90q�6r   $��2��6�   ���	#FFEED47E J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$	 0.7Q�6#   5      �� 5   
   -   5        $��btnClose��5      $��	Odjavi se��6!   $��50��65   $��Right=�6A   $��Bottom=�6]   $	��100��6x   $��5��6�   $��0,0,10,-257q�6�   ���	#FFEED47E 5        5      $	 0.7Q�6#   5      �� 5    
   $��Vase karte:��6   $
��Left=�6&   $��44��6A   $��84,79,0,-22q�6M   $��25(�6b   $	��Top=�6p   $	��140��6�   $��1��6�   $
��Bold"�6�   $��Italic$�6�   �� 5!   
   -   5        $��BtnKarte��5!      $��Karte��6!   $	��117��61   $
��Left=�6=   $��239,91,0,-20q�6o   $��1��6�   ���	#FFEED47E 5"        5#      $	 0.7Q�6#   5%      �� 5&   
   $��Pregled/izmena profila:��6   $
��Left=�62   $��44��6M   $��84,198,0,-141q�6Y   $��25(�6p   $	��Top=�6~   $	��288��6�   $��1��6�   $
��Bold"�6�   $��Italic$�6�   �� 5'   
   -   5        $��	BtnProfil��5'      $��Profil��6"   $	��117��63   $
��Left=�6?   $��239,247,0,-176q�6r   $��1��6�   ���	#FFEED47E 5(        5)      $	 0.7Q�6#   5+      5,      5-      