   M S B A M L   `   `   `  ????D  @SF52-2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SF52_2015.ViewSF52_2015.View  5   	   "    SF52_2015.View.SpisakTermina   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SF52_2015.View     5   	     ? Title$  SpisakTermina??5   	   $	??450??6   $??922.5??6,    ? WindowStartupLocation$ CenterScreen=?6:   ??5	      ?? 5
       j? Stretch$
 Fill=?6    j? 
AlignmentY$	 Top=?6    j? 
AlignmentX$ Center=?6/    ?? ImageSource$% /SF52-2015;component/Salon3.jpg??6C   6s   .??5      ? -   5        $??mainWindowGrid??5      $??1??6   $??3??6+   $y?Visible=?6?   $??	0,0,-66,0q?6T    ? ColumnDefinitions 5      ?? 5      ?? 5       ? RowDefinitions 5      ?? 5      $	??49* ?6   ?? 5      $
??192* ?6   ?? 5      $
??120* ?6   .+?5      ? $??2??6	   $??1??6   .+?5      &   System.Windows.Controls.DataGrid  -   5          Name$ terminiDataGrid??5      	   AutoGenerateColumns	 .  $
??Left=?6a   $??14,11,0,-40q?6|   $	??Top=?6?   
   CanUserAddRows
 .  $	??252??6?   $	??888??6?   ??6)   ??    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Termin ID??6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6T      FontSize$ 17Q?6`      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6.   ??  ?? Path$ 	termin_id?   HeaderTemplate 5      ?? 5   	   .R?5    
   ??  ?? Orientation$ 
Horizontal=?6   .+?5!      ?? ??6   ?? *	Content+ ?? RelativeSource ??  ?? Mode$ TemplatedParent=??? 5#       ??Name$ txtId??6>   -   5        $??25??5#   M    ?? 	MaxLength$ 9??6z   5$      5%   
   5'        5(      $ Sifra??6   $ 70 6T   $ 17Q?6`    .  6*   ?? $ sifra_termina? 5)      ?? 5*   	   .R?5+   
   ?? $ 
Horizontal=?6   .+?5,      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5.      $ txtIdSifra_termina??6   -   5        $??30??5.   0   $ 20??6]   5/      50   
   52        53      $ Vreme??6   $	 100 6S   $ 17Q?6`    .  6*   ?? $ vreme_zauzeca? 54      ?? 55   	   .R?56   
   ?? $ 
Horizontal=?6   .+?57      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 59      $ txtIdVreme_zauzeca??6   -   5        $??70??59   0   $ 25??6]   $??21??6l   5:      5;   
   5=        5>      $	 Dan??6   $	 100 6G   $ 15Q?6T    .  6(   ?? $	 dan? 5?      ?? 5@   	   .R?5A   
   ?? $ 
Horizontal=?6   .+?5B      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5D      $ txtIdDan??6   -   5        $??70??5D   &   $ 20??6S   $??21??6b   5E      5F   
   5H        5J      $	 Tip??6   $	 110 6P   $ 17Q?6]    .  6(   ?? $ tip_tretmana? 5K      ?? 5L   	   .R?5M   
   ?? $ 
Horizontal=?6   .+?5N      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5P      $ txtIdTip_tretmana??6   -   5        $??80??5P   /   $ 15??6\   $??21??6k   5Q      5R   
   5T        5U      $ Radnik??6   $	 100 6Y   $ 17Q?6f    .  6+   ?? $ radnik_ime_prezime? 5V      ?? 5W   	   .R?5X   
   ?? $ 
Horizontal=?6   .+?5Y      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5[      $! txtIdRadnik_zauzeo_termi_id??6>   -   5        $??70??5[   c   $ 9??6?   5\      5]   
   5_        5`      $ 	Broj sobe??6   $ 90 6S   $ 17Q?6_    .  6.   ?? $ 	broj_sobe? 5a      ?? 5b   	   .R?5c   
   ?? $ 
Horizontal=?6   .+?5d      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5f      $ txtIdSoba_termina_id??6>   -	   5        $??25??5f   \   $ 9??6?   5g      5h   
   5j        5k      $ 	Musterija??6   $	 130 6_   $ 17Q?6l    .  6.   ?? $ musterija_ime_prezime? 5l      ?? 5m   	   .R?5n   
   ?? $ 
Horizontal=?6   .+?5o      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5q      $ txtMusterija??6>   -
   5        $	??100??5q   T   $ 9??6?   5r      5s   
   5u        5v      $ Salon ID??6   $	 130 6Y   $ 17Q?6f    .  6-   ?? $ salon_termina_id? 5w      ?? 5x   	   .R?5y   
   ?? $ 
Horizontal=?6   .+?5z      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5|      $ 
txtSalonID??6>   -   5        $	??100??5|   R   $ 9??6?   5}      5~   
   5?      5?      5?      ?? 5?      -   5        $??ObrisiBtnSpisakTermina??5?   g   $??Obrisi??6   $??1??6   $??2??6,   $
??Left=?69   $??	39,62,0,0q?6T   $	??100??6?   $??44??6?   $	??Top=?6?   ?? 5?      -   5        $??IzmeniBtnSpisakTermina??5?   W   $??Izmeni??6   $??44??6   $
??Left=?6(   $??
380,62,0,0q?6C   $	??Top=?6u   $	??100??6?   $??2??6?   6?   ?? 5?      -   5         ??Name$ DodajBtnSpisakTermina??5?   s   $??Dodaj??6   $??0??6   $??2??6+   $??44??68   $
??Left=?6D   $??
220,62,0,0q?6_   $	??Top=?6?   $	??100??6?   6?   ?? 5?      -   5        $??button1??5?   X   $??1??6   $??2??6   $
??Left=?6(   $??181,62,0,40q?6C   $??44??6g   .??5?      ?? $ 
Horizontal=?6   $??31??6*   .+?5?      ?? $'??!/SF52-2015;component/refresh2.png??6   $??Uniform=?68   $??27??6J    ?? BitmapScalingMode$ HighQuality=?6U    J? RenderTransformOrigin$ 	0.525,0.5&?6?   $??0,3,0,2.667q?6?   5?      5?      ?? 5?      $??Termini??6
   
???????$
??Left=?6/   $??	23,10,0,0q?6J   $	??Top=?6]   $??42??6u   $	??165??6?   $??20(?6?   5?      5?      