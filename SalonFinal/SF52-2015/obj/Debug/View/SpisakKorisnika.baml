   M S B A M L   `   `   `  ????D  @SF52-2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SF52_2015.ViewSF52_2015.View  5   	   $    SF52_2015.View.SpisakKorisnika   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SF52_2015.View     5   	     ? Title$  SpisakKorisnika??5   	   $	??450??6!   $	??800??6.    ? WindowStartupLocation$ CenterScreen=?6:   ??5	      ?? 5
       j? Stretch$
 Fill=?6    j? 
AlignmentY$	 Top=?6    j? 
AlignmentX$ Center=?6/    ?? ImageSource$% /SF52-2015;component/Salon3.jpg??6C   6s   .??5      ? -   5        $??mainWindowGrid??5      $??1??6   $??3??6+   $y?Visible=?6?    ? ColumnDefinitions 5      ?? 5      ?? 5       ? RowDefinitions 5      ?? 5      $	??49* ?6   ?? 5      $
??192* ?6   ?? 5      $
??120* ?6   .+?5      ? $??2??6	   $??1??6   .+?5      &   System.Windows.Controls.DataGrid  -   5          Name$ korisniciDataGrid??5      	   AutoGenerateColumns	 .  $
??Left=?6c   $??14,11,0,-14q?6~   $	??Top=?6?   
   CanUserAddRows
 .  $	??226??6?   $	??755??6?   ??6+   ??    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Korisnik ID??6      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6X      FontSize$ 17Q?6e      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   ??  ?? Path$ korisnik_id?   HeaderTemplate 5      ?? 5   	   .R?5    
   ??  ?? Orientation$ 
Horizontal=?6   .+?5!      ?? ??6   ?? *	Content+ ?? RelativeSource ??  ?? Mode$ TemplatedParent=??? 5#       ??Name$ txtId??6>   -   5        $??34??5#   M    ?? 	MaxLength$ 9??6z   5$      5%   
   5'        5(      $	 Ime??6   $	 100 6H   $ 17Q?6U    .  6(   ?? $	 ime? 5)      ?? 5*   	   .R?5+   
   ?? $ 
Horizontal=?6   .+?5,      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5.      $ txtIdIme??6   -   5        $??66??5.   &   $ 20??6S   5/      50   
   52        53      $ Prezime??6   $	 130 6O   $ 17Q?6\    .  6,   ?? $ prezime? 54      ?? 55   	   .R?56   
   ?? $ 
Horizontal=?6   .+?57      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 59      $ txtIdPrezime??6   -   5        $??75??59   *   $ 25??6W   $??21??6f   5:      5;   
   5=        5>      $ Korisnicko ime??6   $	 150 6]   $ 15Q?6j    .  63   ?? $ korisnicko_ime? 5?      ?? 5@   	   .R?5A   
   ?? $ 
Horizontal=?6   .+?5B      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5D      $ txtIdKorisnickoIme??6   -   5        $??62??5D   0   $ 20??6]   $??21??6l   5E      5F   
   5H        5J      $	 Tip??6   $	 140 6G   $ 17Q?6T    .  6(   ?? $	 tip? 5K      ?? 5L   	   .R?5M   
   ?? $ 
Horizontal=?6   .+?5N      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5P      $ txtIdTip??6   -   5        $	??100??5P   &   $ 15??6T   $??21??6c   5Q      5R   
   5T        5V      $ Email??6   $	 140 6K   $ 17Q?6X    .  6*   ?? $ email? 5W      ?? 5X   	   .R?5Y   
   ?? $ 
Horizontal=?6   .+?5Z      ?? ??6   ?? *	Content+ ?? $ TemplatedParent=??? 5\      $ txtEmail??6>   -   5        $??70??5\   P   $ 9??6}   5]      5^   
   5`      5b      5d      ?? 5e      -	   5        $??ObrisiBtnSpisakKorisnika??5e   g   $??Obrisi??6   $??1??6   $??2??6,   $
??Left=?69   $??	79,34,0,0q?6T   $	??100??6?   $??44??6?   $	??Top=?6?   ?? 5f      -
   5        $??IzmeniBtnSpisakKorisnika??5f   W   $??Izmeni??6   $??44??6   $
??Left=?6(   $??
286,34,0,0q?6C   $	??Top=?6w   $	??100??6?   $??2??6?   6?   ?? 5g      -   5         ??Name$ DodajBtnSpisakKorisnika??5g   s   $??Dodaj??6   $??0??6   $??2??6+   $??44??68   $
??Left=?6D   $??
121,34,0,0q?6_   $	??Top=?6?   $	??100??6?   6?   ?? 5i      -   5        $??button1??5i   X   $??1??6   $??2??6   $
??Left=?6(   $??262,41,0,61q?6C   $??44??6g   .??5k      ?? $ 
Horizontal=?6   $??31??6*   .+?5l      ?? $'??!/SF52-2015;component/refresh2.png??6   $??Uniform=?68   $??27??6J    ?? BitmapScalingMode$ HighQuality=?6U    J? RenderTransformOrigin$ 	0.525,0.5&?6?   $	??0,3q?6?   5m      5n      ?? 5o      $??	Korisnici??6
   
???????$
??Left=?61   $??	10,10,0,0q?6L   $	??Top=?6_   $??47??6w   $	??181??6?   $??20(?6?   5p      5q      