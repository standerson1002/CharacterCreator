   M S B A M L   `   `   `  ����N  JWpfCharacterCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfCharacterCreatorWpfCharacterCreator  5   	   *    $WpfCharacterCreator.CharacterCreator   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WpfCharacterCreator     5   	     � Title$  Character Creator��5   	   $	��720��6#   $
��1280��60    � Icon$ 	/logo.png��6=   .��5	      � ��5
   
   �� 5       �� 
StartPoint$ 0.5,0&�6"    �� EndPoint$ 0.5,2&�65   .��5      �  � Color$ Coral��6    � Offset$	 0.1Q�6-   � 5      $ BlanchedAlmond��6   $
 0.25Q�66   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��8* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��20* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   $��1��6    5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5       $��1* �6#   �� 5!      $��1* �6#   �� 5"      $��1* �6#   �� 5#      $��1* �6#   .+�5&      �� -   5         ��Name$ 
btnFriends��5&   K   $��0��6      HeaderButton#��[  6%   $��Friends��6_   6q   �� 5'      -   5        $ btnCharacters��5'   K   $��1��6   #��[  6%   $��
Characters��6b   6w   �� 5(      -   5        $ btnLocations��5(   K   $��2��6   #��[  6%   $��	Locations��6a   6u   �� 5*      -   5        $ 	btnLogout��5*   J   $��4��6     LoginButton#��[ 6%   $��Log Out��6]   6o   �� 5+      -   5        $ 
btnProfile��5+   J   $��5��6   #��[ 6%   $��Profile��6^   $y�Visible=�6p   6�   5-       � 5/   
   -   5        	  �Name$	 	mainFrame��5/   -   $��1��6   $��1��6   
  � NavigationUIVisibility$
 Hidden=�6@   � 51   
   $��3��6   $��1��6   
�������.+�52      �� -   5         ��Name$ panelMessage��52      .+�53      �� -   5         ��Name$ lblMessageTitle��53      �� 54      -	   5         ��Name$ txtMessageDescription��54      55      56      59      5:      