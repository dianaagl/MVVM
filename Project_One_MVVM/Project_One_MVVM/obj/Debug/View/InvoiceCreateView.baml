   M S B A M L   `   `   `  ����K  GProject_One_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Project_One_MVVM.ViewProject_One_MVVM.View  5   	   -    'Project_One_MVVM.View.InvoiceCreateView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Project_One_MVVM.View     5   	     � Title$  InvoiceCreateView��5   	   $	��450��6#   $	��800��60   .��5	      � $��0,0,0,23q�6   .+�5
   
   �� -   5         ��Name$ customer��5
      $��150,95,441,266q�6%   5      �� 5   
   -   5        $ Employee��5      $��150,39,441,322q�6%   5      �� 5   
   -   5        $ Product��5      $��150,153,441,208q�6$   5      �� 5   
   $��37,214,692,144q�6   $��Count��6(    J� RenderTransformOrigin$ 0.492,0.237&�68   �� 5   
   -   5         ��Name$ Count��5      $��150,214,441,153q�6!   $ 0.291,1.176&�6:   .��6^   5      �� 5   
   $��150,266,441,95q�6   $��Add product��6)   ��6@   �� *
AddProduct+6a   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $	��338��6@   $��
389,38,0,0q�6M   $	��Top=�6a   $	��359��6y   �� 5   
   $��150,322,441,39q�6   $��Add Invoice��6*   ��6A   �� *
AddInvoice+6b   �� 5   
   $��Employee��6   $
��Left=�6#   $��	36,39,0,0q�6>   $	��Top=�6Q   �� 5   
   $��Customer��6   $
��Left=�6#   $��	37,95,0,0q�6>   $	��Top=�6Q   $ 0.508,0.038&�6i   �� 5   
   $��Product��6   $
��Left=�6"   $��
36,153,0,0q�6=   $	��Top=�6Q   $��35��6i   5      5       