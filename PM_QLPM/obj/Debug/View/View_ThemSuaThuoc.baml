   M S B A M L   `   `   `  ����B  >PM_QLPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PM_QLPM.ViewPM_QLPM.View  5      A%clr-namespace:PM_QLPM.Core.ConvertersPM_QLPM.Core.Converters  5      5clr-namespace:PM_QLPM.ViewModelPM_QLPM.ViewModel  5
      $    PM_QLPM.View.View_ThemSuaThuoc   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ,localclr-namespace:PM_QLPM.View     5      6core%clr-namespace:PM_QLPM.Core.Converters     5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5	      /	viewModelclr-namespace:PM_QLPM.ViewModel  5
         MaterialDesignPaper#��[  5        AccentColorBrush#���  5        MaterialDesignFont#��[ 5        � Title$  Thêm/sửa thuốc��5      $	��500��5      $	��800��6   $	��500��5      $	��800��6    � WindowStartupLocation$ CenterScreen=�5       � ShowInTaskbar . (  "MahApps.Metro.Controls.MetroWindow   ShowTitleBar .     ShowMinButton .     ShowMaxRestoreButton .     ShowCloseButton .  J� 	AllowDrop .   �� BitmapScalingMode$ HighQuality=�5      	 �� CachingHint$	 Cache=�5      
 �� ClearTypeHint$
 Enabled=�5      $��15(�5       � DataContext 5       3   -PM_QLPM.ViewModel.View_ThemSuaThuoc_ViewModel  5!   
   .��5$      �  � RowDefinitions 5%   
   �� 5&      $	��125 �6   �� 5'      �� 5(      $��60 �6    � ColumnDefinitions 5*   
   �� 5+      $��5* �6   �� 5,      $��4* �6   .+�5.   
   �� -   5        $&�� THÊM THUỐC VÀO ĐƠN THUỐC��5.      $��20(�64    �� TextAlignment$ Center=�5/      $��25��6/   $	��Top=�50      $��122,15,122,0q�60   $��2��51   7   �� 52   
   $	��Top=�6   $��250,55,250,0q�6)   $��50��6?   $��Center=�6K   ���#BDBDBD$��1q�53   '    �� CornerRadius$ 7��6;   $��2��6L   ._�54      � .+�55      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�56      �� -   5         ��Name$ txt_TimKiem��56      $	��220��63   $��15(�6?    � ToolTip$y sTìm kiếm bệnh nhân trong danh sách bằng:
Mã bệnh nhân, Họ tên, Giới tính và/hoặc Địa chỉ��57   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm��58      $��20 10q�59      ��5:   "   �� *
Searcher+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5;      5<      5=      �� 5?   
    �� DisplayMemberPath$ TenThuoc��5A      $��20 0 0 0q�5B      $��0��6%   $��1��65   ��5?      �� *
ViewSource+ �� SelectedItem 5@      �� *PickedThuoc+$ TwoWay=�$ PropertyChanged=�5B   5   � 5D   
   $��1��6   $��1��6   $��
10 40 20 0q�6,    5E      �� 5F      $	��61* �6#   �� 5G      $
��100* �6#   .+�5J      �� $��0��6   $��Cách dùng��6$   $��0 5 0 0q�68   $
��Left=�6I   $	��Top=�6d   �� 5K      $��0��6   $��Số lượng��6$   $��0 52 0 0q�67   $
��Left=�6I   $	��Top=�6d   �� 5L      $��0��6   $��Ghi chú��6$   $��	0 101 0 0q�66   $
��Left=�6I   $	��Top=�6d   �� 5N      $��2��6   $	��180��6'   $
��Left=�5O      $	��Top=�62   $ TenCachDung��5P   ;    �� SelectedValuePath$ Ma_CachDung��5R      ��5P      �� *DS_CachDung+ �� SelectedValue 5Q      �� *Thuoc.Ma_CachDung+$ TwoWay=�$ PropertyChanged=�5R      �� 5T      $��2��6   $��0 50 0 0q�6&   $	��180��68   $
��Left=�5U      $	��Top=�61   ��5V      �� *Thuoc.SoLuong+�� 5X      $��Disabled=�6   $
��Auto=�6D   $��1��5Y      $��	0 100 0 0q�6+   $	��180��6>   $
��Left=�5Z      $	��Top=�66   .��5[      �� $��84��68    �� TextWrapping$
 Wrap=�6D   ��6   �� *Thuoc.GhiChu+6D   5\      5]      �� 5_   
   $ 
Horizontal=�6   $��1��6.   $��2��6>   $��Bottom=�5`      $��Right=�60   $��
20 0 20 10q�6L   .+�5a      �� -   5         ��Name$ btn_OK��5a      $��15(�6%   $��
10,10,0,10q�63   $	��100��6G   $' !Thêm mới hồ sơ bệnh nhân��5b        MaterialDesignFlatButton#��[ 5c      ���#673AB7$
��Auto��6`   .��5e      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5f      �� $��THÊM��6    $��0 0 0 0q�6,   5g      5h      �� 5i      -   5        $ 	btn_Close��5i      $��15(�6(   $��10,10,10,10q�66   $	��100��6K   $' !Thêm mới hồ sơ bệnh nhân��5j      #��[ 5k      ���#673AB7$
��Auto��6`   .��5m      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5n      �� $��THOÁT��6    $��0 0 0 0q�6-   5o      5p      5q      5r      5s      