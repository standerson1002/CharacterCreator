   M S B A M L   `   `   `  ����N  JWpfCharacterCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:WpfCharacterCreator.Pages.Locations#WpfCharacterCreator.Pages.Locations  5      <    6WpfCharacterCreator.Pages.Locations.ViewSingleLocation   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:WpfCharacterCreator.Pages.Locations     5        N� Title$  ViewSingleLocation��5	      .��5      �    BoxGrid#��[  6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��5* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ lblLocationName��5      $��0��6)   $��1��66   $��2��6F   $��Location��6Z     PrimaryTitleLabel#��[ 6m   �� 5   
   -   5        $ 
lblAddress��5      $��1��6$   $��1��61   $��2��6A   $��Address��6U     SmallTitleLabel#��[ 6g   �� 5   
   -   5         ��Name$ txtDescription��5      $��2��6*   $��1��67   $��2��6G     Description#��[ 6[    �� 
IsReadOnly$
 True��6�   �� 5    
   -   5         ��Name$ btnEdit��5       $��3��6"   $��1��6/     WarningButton#��[ 6?   $��Edit Location��6f   6~   �� 5!   
   -   5        $ btnBack��5!      $��3��6"   $��2��6/     
BackButton#��[ 6?   $
��Back��6c   6r   5#      5$      