   M S B A M L   `   `   `  ����N  JWpfCharacterCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:WpfCharacterCreator.Pages.Characters$WpfCharacterCreator.Pages.Characters  5      8    2WpfCharacterCreator.Pages.Characters.ViewCharacter   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:WpfCharacterCreator.Pages.Characters     5        N� Title$  ViewCharacter��5	      .��5      �    BoxGrid#��[  6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��1* �6   �� 5      $��8* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   $��0��6   $��2��6,     
HeaderGrid#��[ 6@    5      �� 5      $��2* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5      �� -   5         ��Name$ lblCharacterNameProfile��5   %   $��0��6   $
��Name��6F     PrimaryTitleLabel#��[ 6U   �� 5      -   5         ��Name$ btnShareCharacter��5   %   $��1��6   $��Share��6`     CallToActionSecondary#��[ 6p   �� 5       -   5        $ btnEditCharacter��5    %   $��2��6   $
��Edit��6_     WarningButton#��[ 6n   5"      �� 5$   
   -   5        $ lblCharacterFullName��5$   A   $��1��6   $��0��6   $��2��6-   $
��Name��6_     TopLabel#��[ 6n   � 5&   
   $��2��6   $��3��6     TabGrid#��[ 60   .+�5'      �� .@�5(      �� $��Traits��6   .��5)      �  5*      �� 5+      $��1* �6,   �� 5,      $��6* �6,   .+�5.      �� -   5        $ 	lblTraits��5.   -   $��0��6      SecondaryTitleLabel#��[ 6@   $��Traits��6m   �� 5/      -   5         ��Name$ 
textTraits��5/   1   $��1��6$   $
��Auto=�6E   $
��Wrap=�6u   51      52      �� 53      $��Skills��6   .��54      �  55      �� 56      $��1* �6,   �� 57      $��6* �6,   .+�5:      �� -   5        $ 	lblSkills��5:   -   $��0��6    #��[ 6@   $��Skills��6m   �� 5;      -   5        $ 
textSkills��5;   1   $��1��6$   $
��Auto=�6E   $
��Wrap=�6u   5<      5=      �� 5>      $��Likes and Dislikes��6   .��5?      �  5@      �� 5A      �� 5B       5D      �� 5E      $��1* �6,   �� 5F      $��5* �6,   .+�5I      �� -	   5        $ lblLikes��5I   =   $��0��6    $��0��6-   #��[ 6O   $��Likes��6|   �� 5J      -
   5        $ 	textLikes��5J   A   $��1��6$   $��0��61   6A   �� 5L      -   5        $ lblDislikes��5L   =   $��0��6    $��1��6-   #��[ 6R   $��Dislikes��6   �� 5M      -   5        $ textDislikes��5M   A   $��1��6$   $��1��61   6A   5O      5P      5Q      5R      �� 5T   
   -   5        $ 
lblCreator��5T   -   $��3��6   $��0��6     SmallTitleLabel#��[ 6A   �� 5U   
   -   5        $ 
lblCreated��5U   -   $��3��6   $��1��6   #��[ 6A   5W      5X      