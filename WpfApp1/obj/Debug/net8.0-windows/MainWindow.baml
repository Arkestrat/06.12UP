   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$%  Окно авторизации��5   	   $	��200��6"   $	��400��6/   .��5	      � 
������ � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��6* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $%��Окно авторизации��6   $��Center=�60   $��Center=�6K   $��	100 0 0 0q�6h   $��20(�6{   
���   �$
��Bold"�6�   5      �� 5   
   $��1��6   $��0��6"   $ Vertical=�62   .+�5      �� $��Логин:��6   $��Right=�6%   $	��Top=�6A   $��	0 7 270 0q�6Y   $
��Bold"�6l   �� 5      $��Right=�6   $��Пароль:��60   $��Arial)�6B   $��13(�6U   $��25��6c   $��	0 0 270 0q�6o   $
��Bold"�6�   5      �� 5   
   $��1��6   $��0��6"   $ Vertical=�62   .+�5      �� -   5        $��LoginTextBox��5      $��Center=�6*   $	��Top=�6G   $��5 10 5 5q�6_   $	��120��6q   G� 5      -   5        $��PasswordBox��5      $��Center=�6-   $	��Top=�6J   $��5q�6b   $	��120��6m   �� 5      -   5        $��btnInput��5      $��1��6%   $��2��65   $��
Войти��6B   $
��Bold"�6R   $��10q�6d   $	��100��6p   $��25��6|   
����ح�6�   5      5      5      