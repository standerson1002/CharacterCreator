   M S B A M L   `   `   `  ����N  JWpfCharacterCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WpfCharacterCreator.Pages.UserWpfCharacterCreator.Pages.User  5      3    -WpfCharacterCreator.Pages.User.ChangePassword   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:WpfCharacterCreator.Pages.User     5        N� Title$  ChangePassword��5	      .��5      �    BoxGrid#��[  6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��5* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��1.5* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   $��1��6   $��2��6-   $��Change Password��6A     PrimaryTitleLabel#��[ 6[   �� 5    
   $��1��6   $��1��6   $��Email��6-     TopLabel#��[ 6=   �� 5!   
   -   5         ��Name$ txtChangePasswordEmail��5!   /   $��2��6   $��1��6     	TextBelow#��[ 6O    �� 	MaxLength$	 100��6r   �� 5#   
   $��1��6   $��2��6   $��Current Password��6-   #��[ 6H   G� 5$   
   -   5         G�Name$ pwdOldPassword��5$   3   $��2��6   $��2��6#     PasswordBelow#��[ 6K   �� 5&   
   $��3��6   $��1��6   $��New Password��6-   #��[ 6D   G� 5'   
   -   5        $ pwdNewPassword��5'   3   $��4��6   $��1��6#   #��[ 6K   �� 5)   
   $��3��6   $��2��6   $��Verify New Password��6-   #��[ 6K   G� 5*   
   -   5        $ pwdConfrimNewPassword��5*   3   $��4��6   $��2��6#   #��[ 6R   �� 5,   
   -   5         ��Name$ btnChangePasswordConfirm��5,   .   $��6��6   $��1��6   $��Change Password��5-        CallToAction#��[ 6+   �� 5.   
   -   5        $ btnChangePasswordCancel��5.   .   $��6��6   $��2��6   $��Cancel��5/        
BackButton#��[ 6"   57      58      