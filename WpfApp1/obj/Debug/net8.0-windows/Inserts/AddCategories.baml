   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp1.InsertsWpfApp1.Inserts  5   	   #    WpfApp1.Inserts.AddCategories   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApp1.Inserts     5   	     � Title$  AddCategories��5      $	��300��6'   $	��500��64   .��5	      � 
����ح� � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��3* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6#   
���/���$��2��6V   .+�5      �� $-��'Добавление категории��6   $��10 0 0 0q�64   $��20(�6F   $	��249��6T   $��Arial)�6`   $
��Bold"�6s   $��29��6�   �� 5      -   5        $��btnGoToTheMainWindow��5      $(��"Перейти на главную��61   $
��Bold"�6N   $��16(�6`   $��Center=�6n   $��60 0 0 0q�6�   $��23��6�   $	��178��6�   6�   5      �� 5   
   $��1��6   .+�5      �� $)��#Название категории��6   $��0��5   	   $��0��5   	   $��Center=�5   	   $��30q�5   	   $��14(�6   5      �� 5    
   $��2��6   .+�5!      �� $��Описание��6   $��0��5"   	   $��0��5#   	   $��Center=�5$   	   $��30q�5%   	   $��14(�6   5&      �� 5*   
   $��1��6   $��2��6"   .+�5+      �� -   5        $��TxtCategories��5+      $��29��5,   +   $	��258��67   $��0 20 0 0q�6C   ��6   �� *CategoryName+5-      5.      �� 5/   
   $��2��6   $��2��6"   .+�50      �� -   5        $��TxtDescription��50      $��29��51   *   $	��258��66   $��0 20 0 0q�6B   ��6   �� *Description+52      53      �� 55   
   $��3��6   $��2��6"   .+�56      �� -   5        $��SaveCategory��56      $��Сохранить��6)   $
��Bold"�6>   $��20(�6P   $��33��6^   $	��168��6j   
�����w�$��0 15 0 0q�6�   57      58      59      