   M S B A M L   `   `   `  ����N  JWpfCharacterCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:WpfCharacterCreator.Pages.Locations#WpfCharacterCreator.Pages.Locations  5      6    0WpfCharacterCreator.Pages.Locations.EditLocation   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:WpfCharacterCreator.Pages.Locations     5        N� Title$  EditLocation��5	      .��5      �    BoxGrid#��[  6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��8* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��6   $��1��6   $��2��6-   $��Update Location��6A     PrimaryTitleLabel#��[ 6[   �� 5!   
   $��1��6   $��1��6   $
��Name��6-     	LeftLabel#��[ 6<   �� 5"   
   -   5         ��Name$ textName��5"      $��1��6$   $��2��61   �� 5$   
   $��2��6   $��1��6   $��Country��6-   #��[ 6?   �� 5%   
   -   5         ��Name$ comboCountries��5%   0   $��2��6   $��2��6     �� DisplayMemberPath$ 	CountryID��5'      ��5&      �� 5(      �� 5+   
   $��3��6   $��1��6   $��Subdivision��6-   #��[ 6C   �� 5,   
   -   5        $ comboSubdivisions��5,   0   $��3��6   $��2��6    $ SubdivisionName��5.      ��5-      �� 5/      �� 52   
   $��4��6   $��1��6   $
��City��6-   #��[ 6<   �� 53   
   -   5        $ comboCities��53   0   $��4��6   $��2��6    $ CityName��55       �� SelectedValuePath$
 City��56      ��54      �� 56      �� 59   
   $��5��6   $��1��6   $��Address��6-   #��[ 6?   �� 5:   
   -   5        $ textAddress��5:      $��5��6'   $��2��64   �� 5<   
   $��6��6   $��1��6   $��Description��6-     TopLabel#��[ 6C   �� 5=   
   -   5        $ textDescription��5=      $��7��6+   $��1��68   $��2��6H     Description#��[ 6\   � 5?   
   $��8��6   $��1��6   $��2��6,    5@      �� 5A      �� 5B      �� 5C      .+�5E      �� -   5         ��Name$ btnUpdateLocation��5E   %   $��0��6   $��Update Location��6@     CallToAction#��[ 6Z   6�   �� 5F      -   5        $ btnDeleteLocation��5F   %   $��1��6   $��Delete Location��6@     DangerButton#��[ 6Z   6�   �� 5G      -	   5        $ 	btnCancel��5G   %   $��2��6   $
��Back��68     
BackButton#��[ 6G   6k   5H      5J      5K      