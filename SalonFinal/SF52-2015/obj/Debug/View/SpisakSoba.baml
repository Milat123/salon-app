   M S B A M L   `   `   `  ????D  @SF52-2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SF52_2015.ViewSF52_2015.View  5   	       SF52_2015.View.SpisakSoba   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SF52_2015.View     5   	     ? Title$  
SpisakSoba??5   	   $	??450??6   $	??800??6)    ? WindowStartupLocation$ CenterScreen=?65   ??5	      ?? 5
       j? Stretch$
 Fill=?6    j? 
AlignmentY$	 Top=?6    j? 
AlignmentX$ Center=?6/    ?? ImageSource$% /SF52-2015;component/Salon3.jpg??6C   6s   .??5      ? -   5        $??mainWindowGrid??5      $??1??6   $??3??6+   $y?Visible=?6?    ? ColumnDefinitions 5      ?? 5      ?? 5       ? RowDefinitions 5      ?? 5      $	??49* ?6   ?? 5      $
??192* ?6   ?? 5      $
??120* ?6   .+?5      ? $??2??6	   $??1??6   .+?5      &   System.Windows.Controls.DataGrid  -   5          Name$ sobaDataGrid??5      	   AutoGenerateColumns	 .  $
??Left=?6^   $??14,11,0,-39q?6y   $	??Top=?6?   
   CanUserAddRows
 .  $	??251??6?   $	??700??6?   ??6&   ??    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Soba ID??6      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6P      FontSize$ 17Q?6]      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6,   ??  ?? Path$ soba_id?   HeaderTemplate 5      ?? 5   	   .R?5    
   ??  ?? Orientation$ 
Horizontal=?6   .+?5!      ?? ??6   ?? *	Content+ ?? RelativeSource ??  ?? Mode$ TemplatedParent=??? 5#       ??Name$ txtId??6>   -   5        $??34??5#   M    ?? 	MaxLength$ 9??6z   5$      5%   
   5'        5(      $ Sifra??6   $	 100 6L   $ 17Q?6Y    .  6*   ?? $ sifra? 5)      ?? 5*   	   .R?5+   
   ?? $ 
Horizontal=?6   .+?5,      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5.      $ 
txtIdSifra??6   -   5        $??66??5.   (   $ 20??6U   5/      50   
   52        53      $ 	Broj Sobe??6   $	 100 6S   $ 17Q?6`    .  6.   ?? $ 	broj_sobe? 54      ?? 55   	   .R?56   
   ?? $ 
Horizontal=?6   .+?57      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 59      $ txtIdBroj_sobe??6   -   5        $??51??59   ,   $ 25??6Y   $??21??6h   5:      5;   
   5=        5>      $ Broj kreveta??6   $	 150 6Y   $ 15Q?6f    .  61   ?? $ broj_kreveta? 5?      ?? 5@   	   .R?5A   
   ?? $ 
Horizontal=?6   .+?5B      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5D      $ txtIdBroj_kreveta??6   -   5        $??62??5D   /   $ 20??6\   $??21??6k   5E      5F   
   5H        5J      $	 Tip??6   $	 150 6L   $ 17Q?6Y    .  6(   ?? $ tip_sobe? 5K      ?? 5L   	   .R?5M   
   ?? $ 
Horizontal=?6   .+?5N      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5P      $ txtIdTip_sobe??6   -   5        $	??120??5P   +   $ 15??6Y   $??21??6h   5Q      5R   
   5T        5U      $ Salon ID??6   $	 100 6Q   $ 17Q?6^    .  6-   ?? $ salon_id? 5V      ?? 5W   	   .R?5X   
   ?? $ 
Horizontal=?6   .+?5Y      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5[      $ txtIdSalon_id??6>   -   5        $??34??5[   U   $ 9??6?   5\      5]   
   5_      5a      5c      ?? 5d      -	   5        $??ObrisiBtnSpisakSoba??5d   g   $??Obrisi??6   $??1??6   $??2??6,   $
??Left=?69   $??	10,63,0,0q?6T   $	??100??6?   $??44??6?   $	??Top=?6?   ?? 5e      -
   5        $??IzmeniBtnSpisakSoba??5e   W   $??Izmeni??6   $??44??6   $
??Left=?6(   $??
263,63,0,0q?6C   $	??Top=?6r   $	??100??6?   $??2??6?   6?   ?? 5f      -   5         ??Name$ DodajBtnSpisakSoba??5f   s   $??Dodaj??6   $??0??6   $??2??6+   $??44??68   $
??Left=?6D   $??
131,63,0,0q?6_   $	??Top=?6?   $	??100??6?   6?   ?? 5h      -   5        $??button1??5h   X   $??1??6   $??2??6   $
??Left=?6(   $??169,70,0,32q?6C   $??44??6g   .??5j      ?? $ 
Horizontal=?6   $??31??6*   .+?5k      ?? $'??!/SF52-2015;component/refresh2.png??6   $??Uniform=?68   $??27??6J    ?? BitmapScalingMode$ HighQuality=?6U    J? RenderTransformOrigin$ 	0.525,0.5&?6?   $??0,3,0,2.667q?6?   5l      5m      ?? 5n      $
??Sobe??6
   
???????$
??Left=?6,   $??	28,10,0,0q?6G   $	??Top=?6Z   $??42??6r   $	??203??6~   $??20(?6?   5o      5p      