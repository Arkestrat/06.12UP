   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp1.WindowsWpfApp1.Windows  5   	   !    WpfApp1.Windows.WindowUsers   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApp1.Windows     5   	     � Title$  WindowUsers��5      $	��450��6#   $	��800��60   .��5	      � 
���2͚� � RowDefinitions 5
   
   �� 5      $
��0.2* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��1.2* �6   �� 5      $��4* �6   .+�5   
   �� $��0��6   $��1��6"    �� Orientation$ Vertical=�62   
����ح�.+�5      �� $��Пользователи��6   $��20q�6,   $��20(�68   $	��147��6F   $
��Left=�6R   $��Arial)�6m   $
��Bold"�6�   �� 5      -   5        $��btnAddUsers��5      $,��&Перейти к добавлению��6(   $��Center=�6G   $��0 -60 100 0q�6d   $
��Bold"�6y   $��15(�6�   $��25��6�   $	��179��6�   
����ح�6�   �� 5      -   5        $��btnMainWindow��5      $(��"Перейти на главную��6*   $��Center=�6G   $��350 -60 0 0q�6d   $
��Bold"�6y   $��15(�6�   $��25��6�   $	��199��6�   
����ح�6�   5      �� 5   
   $��1��6   $��1��6"   $ Vertical=�62   $��0 0 0 68q�6I   $��2��6[   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dtgUsers��5         AutoGenerateColumns$ False��6'      CanUserAddRows$ False��6C      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Логин��5         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5      1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5      �� *Login+5        5      $ Пароль��5       $ * 5!      	 5      �� *
Password+5!        5"      $' !Электронная почта��5$      $ * 5%      	 5#      �� *Email+5%      5'      5(      �� 5)   
   $ Vertical=�6   $	��Top=�5*      
�������$��1,0,0,0q�6@   $��2��6Q   .+�5+      �� $,��&Сортировка по логину��6   �� 5,      $ Vertical=�6   $��Center=�5-      .+�5.      	� -   5        
 	�Name$

 rbUp��5.      $!��по возрастанию��6,   6E   	� 5/      -   5        $
 rdDown��5/      $��по убыванию��6.   6D   50      �� 51      $"��Поиск по логину��6   �� 52      -   5        $��	txtSearch��52      53      �� 55      $*��$Фильтрация по почте��6   �� 56      -   5        $��cmbEmail��56      57      �� 59      $,��&Фильтрация по логину��6   �� 5:      -   5        $��cmbLogin��5:      5;      5=      �� 5>   
   $��1��6   $��0��6"   .+�5?      �� -	   5        $��Delete��5?      $
��Bold"�6#   $��15(�65   $��Удалить��6C   $��Center=�6U   $��	0 250 0 0q�6r   $��31��6�   $	��151��6�   
����ح�6�   5@      5A      5B      