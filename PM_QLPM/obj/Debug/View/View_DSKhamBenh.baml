   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      B >PM_QLPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PM_QLPM.ViewPM_QLPM.View 5      5clr-namespace:PM_QLPM.ViewModelPM_QLPM.ViewModel 5      A%clr-namespace:PM_QLPM.Core.ConvertersPM_QLPM.Core.Converters 5	      "   PM_QLPM.View.View_DSKhamBenh   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      9system&clr-namespace:System;assembly=mscorlib     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:PM_QLPM.View     5      5	viewModelclr-namespace:PM_QLPM.ViewModel     5      6core%clr-namespace:PM_QLPM.Core.Converters     5	      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5
        � 	Resources  5      7  1PM_QLPM.Core.Converters.AddingVisibilityConverter   AddingVisibilityConverter9  3PM_QLPM.Core.Converters.RemovingVisibilityConverter  RemovingVisibilityConverter9  3PM_QLPM.Core.Converters.PrintingVisibilityConverter  PrintingVisibilityConverter4  .PM_QLPM.Core.Converters.GenreToStringConverter  GenreToStringConverter��%t   &	        &	      &	 &     &	 9       5   
   6)     5   
   6+     5   
   6+     5   
   6&   5       � DataContext 5      1  +PM_QLPM.ViewModel.View_DSKhamBenh_ViewModel  5   
   .��5      �� $
��Auto=�6   $
��Auto=�5      .��5   
   � .+�5      �� $��1��6   $��1��6(   $��DANH SÁCH KHÁM BỆNH��5      $��20(�63    �� TextAlignment$ Center=�5      $	��800��6/   $��25��6;   $	��Top=�5      $��0,0,0,0q�60   �� 5      $	��Top=�6   $��
40 40 40 0q�6-   $��50��6A   ���#BDBDBD$��1q�5    +    �� CornerRadius$ 7��6?   ._�5!      � .+�5"      ��  �� Orientation$ 
Horizontal=�6!   $
��Left=�6:   .+�5#      �� -   5         ��Name$ btn_Them��5#   !   $��15(�63   $��
10,10,0,10q�6A   $	��100��6U    � ToolTip$4 .Thêm mới bệnh nhân vào danh sách khám��5$   !     MaterialDesignFlatButton#��[ 5%   !   ���#673AB7$
��Auto��6h   ��5&   !   �� *CM_AddClicked+{�5'      `� 5(   "    `� 	Converter# [  6/   .1�5)   &   ��  �� Path$ DS_KhamBenh.Count�6.   �� 5*   &   $ 
DatePicked�6.   5+   #   .��5-      �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5.   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]	   Kind$
	 Plus=�6:   $��20��6F   $��20��6R   �� 5/   "   $��THÊM��6,   $��5 0 0 0q�68   50      51      �� 52      -   5        $ btn_Xoa��52   !   $��15(�62   $��
10,10,0,10q�6@   $	��100��6T   $/ )Xoá bệnh nhân khỏi danh sách khám��53   !   #��[ 54   !   ���#673AB7$
��Auto��6h   ��55   !   �� *CM_DeleteClicked+��56   !   �� 
 �� ElementName$
 listView_DanhSachKhamBenh��$ SelectedItems�{�57      `� 58   "   # [ 6/   .1�59   &   �� $ DS_KhamBenh.Count�6.   �� 5:   &   $ 
DatePicked�6.   5;   #   .��5=      �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5>   "     $	 Minus=�6:   $��20��6G   $��20��6S   �� 5?   "   $
��XOÁ��6,   $��5 0 0 0q�67   5@      5A      �� 5B      -   5        $ btn_In��5B   !   $��15(�61   $��
10,10,0,10q�6?   $	��100��6S   $  In danh sách khám bệnh��5C   !   #��[ 5D   !   ���#673AB7$
��Auto��6h   ��5E   !   �� *CM_PrintClicked+{�5F      `� 5G   "   # [ 6/   .1�5H   &   �� $ DS_KhamBenh.Count�6.   �� 5I   &   $ 
DatePicked�6.   5J   #   .��5L      �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5M   "     $	 Printer=�6:   $��20��6I   $��20��6U   �� 5N   "   $��IN��6,   $��5 0 0 0q�66   5O      5P      5Q      �� 5S      $ 
Horizontal=�6!   $��Right=�6:   $��50 0 0 0q�6V   .+�5T      (  "System.Windows.Controls.DatePicker   ( $MaterialDesignFloatingHintDatePicker#��[ 6%   $: 4Lựa chọn ngày để xem danh sách khám bệnh��5U   %   $��15(�5V   %   $��DemiBold"�63   $��
0 10 30 10q�5W   z      SelectedDate 6%   �� *
DatePicked+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6z   �� 5X      -   5         ��Name$ txt_TimKiem��5X   "   $	��220��67   $��15(�6C   $y sTìm kiếm bệnh nhân trong danh sách bằng:
Mã bệnh nhân, Họ tên, Giới tính và/hoặc Địa chỉ��5Y   "   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Tìm kiếm��5Z      $��
0,10,10,10q�5[      ��5\   "   �� *
Searcher+$ TwoWay=�$ PropertyChanged=�5]      5^      5_      &
   System.Windows.Controls.DataGrid
  5a      -   5         
 Name$ listView_DanhSachKhamBenh��5a      $��15(�6:   $��
40,95,40,0q�6H   -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 10 8 8 8q�5b         ColumnHeaderPadding$ 8q�5c       
  AutoGenerateColumns .   
  CanUserAddRows .   
  SelectionMode$ Extended=�5f       
  SelectionUnit$ FullRow=�5g       
  
IsReadOnly .  
  CanUserSortColumns . ��5j      �� *
ViewSource+ � ContextMenu 5k      �� 5l      .@�5m      m� $
��Xoá��6#   $/ )Xoá bệnh nhân khỏi danh sách khám��5p   #    m� Command 5n   #   �� *CM_DeleteClicked+ m� CommandParameter 5o   #   �� $
 listView_DanhSachKhamBenh��$ SelectedItems�5p   #   5q       
  Columns 5s      0  *System.Windows.Controls.DataGridTextColumn  5t      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã bệnh nhân��5u   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5t   )   �� *Ma_BenhNhan+5u   )     5v      $ 	Họ tên��5w   )    5v   )   �� *HoTen+5w   )     5x      $ Giới tính��5y   )    5x   )   �� *
GioiTinh+ �� 	Converter# [ 5y   )     5z      $ 	Năm sinh��5{   )    5z   )   �� *	NamSinh+  �� StringFormat$  {0:dd/MM/yyyy}��5{   )     5|      $ Địa chỉ��5}   )    5|   )   �� *DiaChi+5}   )   5      5�      5�      5�      