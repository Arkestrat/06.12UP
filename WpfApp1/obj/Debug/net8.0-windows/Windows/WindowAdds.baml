   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp1.WindowsWpfApp1.Windows  5   	        WpfApp1.Windows.WindowAdds   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApp1.Windows     5   	     � Title$  
WindowAdds��5   	   $	��450��6   $	��800��6)   .��5	      � 
���2͚� � RowDefinitions 5
   
   �� 5      $
��0.2* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��1.2* �6   �� 5      $��4* �6   .+�5   
   �� $��0��6   $��1��6"    �� Orientation$ Vertical=�62   
����ح�.+�5      �� $��Объявления��6   $��20q�6*   $��20(�66   $	��129��6D   $
��Left=�6P   $��Arial)�6k   $
��Bold"�6~   �� 5      -   5        $��
btnAddAdds��5      $,��&Перейти к добавлению��6'   $��Center=�6F   $��0 -60 100 0q�6c   $��25��6x   $	��190��6�   $
��Bold"�6�   $��15(�6�   
����ح�6�   �� 5      -   5        $��btnMainWindow��5      $(��"Перейти на главную��6*   $��Center=�6G   $��350 -60 0 0q�6d   $��25��6y   $	��199��6�   $
��Bold"�6�   $��15(�6�   
����ح�6�   5      �� 5   
   $��2��6   $��1��6"   $ Vertical=�62   $��0 0 0 68q�6I   $��2��6[   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dtgAdds��5         AutoGenerateColumns$ False��6&      CanUserAddRows$ False��6B      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Идентификатор��5         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5      1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5      �� *AddId+5        5      $ Название��5       $ * 5!      	 5      �� *Title+5!        5"      $ Описание��5$      $ * 5%      	 5#      �� *Description+5%        5&      $ Цена��5(      $ * 5)      	 5'      �� *Price+5)        5*      $ Статус��5,      $ * 5-      	 5+      �� *Status+5-        5.      $ Категория��50      $ * 51      	 5/      �� *CategoryName+51      53      54      �� 55   
   $ Vertical=�6   $	��Top=�56      
�������$��1,0,0,0q�6@   $��2��6Q   .+�57      �� $#��Сортировка цены��6   �� 58      $ Vertical=�6   $��Center=�59      .+�5:      	� -   5        
 	�Name$

 rbUp��5:      $!��по возрастанию��6,   6E   	� 5;      -   5        $
 rdDown��5;      $��по убыванию��6.   6D   5<      �� 5=      $&�� Поиск по названию��6   �� 5>      -   5        $��	txtSearch��5>      5?      �� 5A      $(��"Фильтрация по цене��6   �� 5B      -   5        $��cmbPrice_Client��5B      5C      �� 5E      $.��(Фильтрация по статусу��6   �� 5F      -   5        $��	cmbStatus��5F      5G      5I      �� 5J   
   $��1��6   $��0��6"   .+�5K      �� -	   5        $��
DeleteAdds��5K      $
��Bold"�6'   $��15(�69   $��Удалить��6G   $��Center=�6Y   $��	0 250 0 0q�6v   $��31��6�   $	��151��6�   
����ح�6�   5L      5M      5N      