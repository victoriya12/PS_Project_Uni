   M S B A M L   `   `   `  ����D  @ExpenseIt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ExpenseIt	ExpenseIt  5   	       ExpenseIt.ExpenseItHome   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ExpenseIt     5   	     � Title$  ExpenseIt-Home��5   	   $	��450��6    $	��800��6-   .��5	      � $��
10,0,10,10q�6    � ColumnDefinitions 5   
   �� 5      �� 5      $	��230 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��1��6   ��6    ��  �� RelativeSource ��  �� AncestorType" � �� Path$ MainCaptionText�6�   �� 5   
   $��35��6    �� Padding$ 5q�6   ���#4E87D4$��1��6>   $��1��6N   ._�5      �� $��Center=�6   
�������.��6C   Names6J   5      �� 5   
   -   5         ��Name$ peopleListBox��5   �    �� SelectedIndex$ 0��6�   $��1��6�   $��2��6�   ��6   ��  �� " �$ ExpenseDataSource���5      �� 5      .R�5      �� 
���   ���6   �� $
 Name�5       5!      5#      �� 5%   
   $��0��6   $��2��6"   ��6/   �� $ PersonsChecked�6]   �� 5'   
   $��0,10,0,0q�6   $��1��6#   $��4��63   $	��125��6@   $��25��6L   $��right=�6X   ��6t   �� 	 �� ElementName$	 peopleListBox��$ SelectedItem.Name�6�   �� 5(   
   $��0��6   $��3��6    ��6-   �� $ LastChecked���5)   
   �� 5*      
 j� Stretch$

 Fill=�6    �� ImageSource$, &C:\Users\victo\Downloads\watermark.png��6(    j� 
AlignmentY$	 Top=�6]    j� 
AlignmentX$ Center=�6n   5,      5.      