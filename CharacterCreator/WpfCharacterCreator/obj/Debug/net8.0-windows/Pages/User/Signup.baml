   M S B A M L   `   `   `  ����N  JWpfCharacterCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WpfCharacterCreator.PagesWpfCharacterCreator.Pages  5      &     WpfCharacterCreator.Pages.Signup   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:WpfCharacterCreator.Pages     5        N� Title$  Signup��5	      .��5      �    BoxGrid#��[  6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��5* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��.75* �6   �� 5      $��1.25* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��6   $��1��6   $��2��6-   $��Create a New Account��6A     PrimaryTitleLabel#��[ 6`   �� 5!   
   $��1��6   $��1��6   $��Username��6-     TopLabel#��[ 6@   �� 5"   
   -   5         ��Name$ txtInsertUsername��5"   /   $��2��6   $��1��6    �� 	MaxLength$ 20��6J     	TextBelow#��[ 6Y   �� 5$   
   $��1��6   $��2��6   $��Email��6-   #��[ 6=   �� 5%   
   -   5        $ txtInsertEmail��5%   /   $��2��6   $��2��6   $	 100��6G   #��[ 6W   �� 5'   
   $��3��6   $��1��6   $��Choose Password��6-   #��[ 6G   G� 5(   
   -   5         G�Name$ pwdChoosePassword��5(   3   $��4��6   $��1��6#     PasswordBelow#��[ 6N   �� 5*   
   $��3��6   $��2��6   $��Verify Password��6-   #��[ 6G   G� 5+   
   -   5        $ pwdVerifyPassword��5+   3   $��4��6   $��2��6#   #��[ 6N   �� 5-   
   -   5         ��Name$ btnCreateAccount��5-   .   $��6��6   $��1��6   $��Create Account��5.   0     CallToAction#��[ 6I   �� 50   
   -   5        $ btnBackToLogin��50   .   $��6��6   $��2��6   $��Return to Login Page��51   +     
BackButton#��[ 6J   54      55      