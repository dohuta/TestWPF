   M S B A M L   `   `   `  ����B  >PM_QLPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PM_QLPM.ViewPM_QLPM.View  5      A%clr-namespace:PM_QLPM.Core.ConvertersPM_QLPM.Core.Converters  5      $    PM_QLPM.View.View_ThemBenhNhan   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ,localclr-namespace:PM_QLPM.View     5      6core%clr-namespace:PM_QLPM.Core.Converters     5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5	         MaterialDesignPaper#��[  5        AccentColorBrush#���  5        MaterialDesignFont#��[ 5        � Title$  Thêm bệnh nhân��5      $	��500��5      $	��800��6   $	��500��5      $	��800��6    � WindowStartupLocation$ CenterScreen=�5       � ShowInTaskbar . (  "MahApps.Metro.Controls.MetroWindow   ShowTitleBar .     ShowMinButton .     ShowMaxRestoreButton .     ShowCloseButton .  J� 	AllowDrop .   �� BitmapScalingMode$ HighQuality=�5      	 �� CachingHint$	 Cache=�5      
 �� ClearTypeHint$
 Enabled=�5       � 	Resources 5      2   ,PM_QLPM.Core.Converters.GenreToBoolConverter  SexToBoolConverter<   6PM_QLPM.Core.Converters.EditingPatientProfileConverter " EditingPatientProfileConverter4   .PM_QLPM.Core.Converters.GenreToStringConverter  GenreToStringConverter�� 5   
   %W   &	       &	      &	 &       5       6(     5!      62     5"      6*   5#      .��5&      )  #MaterialDesignThemes.Wpf.DialogHost  -   5           DialogContent 5'   
   �� 5(      $��16q�6   .+�5*      �� $��0 10 0 0q�6   $��15(�6.    �� TextAlignment$ Center=�6<   )'Nhập thông tin hồ sơ bệnh nhân6s   �� 5+      -   5         ��Name$ 	txt_Hoten��5+      $��0 15 0 0q�6-   $��14(�6?    % !MaterialDesignFloatingHintTextBox#��[ 5,      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Họ tên:��5-      $��Stretch=�5.      �� 5/       �� Orientation$ 
Horizontal=�6   $��0 15 0 0q�66   .+�50      �� $��Giới tính:��6   $��14(�61   	� 51      -   5         	�Name$ rad_Nam��51   "   $	��Nam��63   $��14(�6A   $��10 0 0 0q�6O   $��Center=�6a   	� 52      -   5        $ rad_Nu��52   "   $
��Nữ��62   $��14(�6?   $��10 0 0 0q�6M   $��Center=�6_   53      (  "System.Windows.Controls.DatePicker  54      -   5          Name$ txt_NgaySinh��54      $��Stretch=�63   $��0,10,0,0q�6Q   $ Ngày sinh:��55      $��14(�6I    ( $MaterialDesignFloatingHintDatePicker#��[ 56         SelectedDate 57      ��  �� Path$ BenhNhan.NamSinh� �� Mode$ TwoWay=��� 58      -   5        $ 
txt_DiaChi��58      $��0,10,0,0q�6.   $��14(�6@   #��[ 59      $ Địa chỉ:��5:      $��Stretch=�5;      �� 5>      $��Right=�6   $ 
Horizontal=�69   $��0,10,0,0q�6R   .+�5?      �� $��0,8,8,0q�6   $2��,materialDesign:DialogHost.CloseDialogCommand��5@       �� 	IsDefault .   MaterialDesignFlatButton#��[ 5B      ��5C   "   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5D   5   ��6&   3system&clr-namespace:System;assembly=mscorlib  65   True��6q   .��5E   ;   THÊM5G      �� 5H      $��0,8,8,0q�6   $2��,materialDesign:DialogHost.CloseDialogCommand��5I       �� IsCancel . #��[ 5K      ��5L   "   1&clr-namespace:System;assembly=mscorlibSystem 5M   5   ��6&   3system&clr-namespace:System;assembly=mscorlib  65   	False��6r   .��5N   ;   
BỎ QUA5P      5Q      5R      .��5U   
   � .+�5V      �� -   5        $.��(THÊM BỆNH NHÂN VÀO DANH SÁCH KHÁM��5V      $��20(�6A   $ Center=�5W      $��25��6/   $	��Top=�5X      $��122,15,122,0q�60   5Y      �� 5[      -   5        $	��Top=�5[      $��Center=�60   $ Center=�5\      $��15(�5]      $	��548��6&   $��120 55 120 0q�62   caLựa chọn bệnh nhân cần thêm vào danh sách khám từ danh sách hồ sơ bên dưới5`      �� 5b      $	��Top=�6   $��
20 90 20 0q�6-   $��50��6A   ���#BDBDBD$��1q�5c   '    �� CornerRadius$ 7��6;   ._�5d      � .+�5e      �� $ 
Horizontal=�6!   $
��Left=�6:   .+�5f      �� -	   5         ��Name$ btn_Them��5f   !   $��15(�63   $��
20,10,0,10q�6A   $	��150��6U    � ToolTip$' !Thêm mới hồ sơ bệnh nhân��5g   !   #��[ 5h   !   ���#673AB7$
��Auto��6h      OpenDialogCommand#��Z 5i   !   .��5j      �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5k   "   '  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]] 	  Kind$
 Plus=�6:   $��20��6F   $��20��6R   �� 5l   "   $��THÊM HỒ SƠ��6,   $��5 0 0 0q�6>   5m      5n      �� 5p      -
   5        $ btn_Sua��5p   !   $��15(�62   $��
10,10,0,10q�6@   $	��100��6T   $, &Sửa thông tin hồ sơ bệnh nhân��5q   !   #��[ 5r   !   ���#673AB7$
��Auto��6h   ��5s   !   �� *CM_PrintClicked+{�5t      `� 5u   "    `� 	Converter# [ 6/   .1�5v   &   ��  �� ElementName$ listView_DanhSachKhamBenh��6.   $ SelectedItems.Count�6V   �� 5w   &   $ DS_HoSo.Count�6.   5x   #   .��5z      �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5{   "     $ Pencil=�6:   $��20��6H   $��20��6T   �� 5|   "   $��SỬA��6,   $��5 0 0 0q�67   5}      5~      5      �� 5�      $ 
Horizontal=�6!   $��Right=�6:   $��	50 0 10 0q�6V   .+�5�      �� -   5        $ txt_TimKiem��5�   "   $	��220��67   $��15(�6C   $y sTìm kiếm bệnh nhân trong danh sách bằng:
Mã bệnh nhân, Họ tên, Giới tính và/hoặc Địa chỉ��5�   "   $ Tìm kiếm��5�      $��
0,10,10,10q�5�      ��5�   "   �� *
Searcher+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5�      5�      5�      &
   System.Windows.Controls.DataGrid
  5�      -   5          
 Name$  listView_DanhSachKhamBenh��5�      $��15(�6:   $��20,140,20,61q�6H   
������ -  'MaterialDesignThemes.Wpf.DataGridAssist!   CellPadding$! 13 8 8 8q�5�      "   ColumnHeaderPadding$" 8q�5�      # 
  AutoGenerateColumns# .  $ 
  CanUserAddRows$ .  % 
  SelectionMode$% Single=�5�      & 
  SelectionUnit$& FullRow=�5�      ' 
  
IsReadOnly' . ( 
  CanUserSortColumns( . ��5�      �� *
ViewSource+) �� SelectedItem) 5�      �� *SelectedBenhNhan+* 
  Columns* 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn+   Header$+ Mã bệnh nhân��5�   )   1  +System.Windows.Controls.DataGridBoundColumn,   Binding, 5�   )   �� *Ma_BenhNhan+5�   )     5�      $+ 	Họ tên��5�   )   , 5�   )   �� *Hoten+5�   )     5�      $+ Giới tính��5�   )   , 5�   )   �� *
GioiTinh+- �� 	Converter#- [ 5�   )     5�      $+ 	Năm sinh��5�   )   , 5�   )   �� *	NamSinh+. �� StringFormat$. {0:dd/MM/yyyy}��5�   )     5�      $+ Địa chỉ��5�   )   , 5�   )   �� *DiaChi+5�   )   5�      �� 5�      $ 
Horizontal=�6   $��Bottom=�62   $��Right=�6M   $��
20 0 20 10q�6i   .+�5�      �� -   5        $ btn_OK��5�      $��15(�6)   $��
10,10,0,10q�67   $	��100��6K   $' !Thêm mới hồ sơ bệnh nhân��5�      #��[ 5�      ���#673AB7$
��Auto��6`   .��5�      �� $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6U   .+�5�      �� $��THÊM��6$   $��0 0 0 0q�60   5�      5�      �� 5�      -   5        $ 	btn_Close��5�      $��15(�6,   $��10,10,10,10q�6:   $	��100��6O   $' !Thêm mới hồ sơ bệnh nhân��5�      #��[ 5�      ���#673AB7$
��Auto��6`   .��5�      �� $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6U   .+�5�      �� $��THOÁT��6$   $��0 0 0 0q�61   5�      5�      5�      5�      5�      5�      