   M S B A M L   `   `   `  ????D  @SF52-2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SF52_2015.View.ConvertersSF52_2015.View.Converters  5   	   $    SF52_2015.View.IzmenaKorisnika   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SF52_2015.View.Converters     5   	     ? Title$  IzmeniKorisnika??5   	   $	??578??6!   $	??729??6.    ? WindowStartupLocation$ CenterScreen=?6:   ??5	      ?? 5
       j? Stretch$
 Fill=?6    j? 
AlignmentY$	 Top=?6    j? 
AlignmentX$ Center=?6/    ?? ImageSource$% /SF52-2015;component/Salon2.jpg??6C   6s   .??5      ? -   5        $??mainWindowGrid??5      $??1??6   $??3??6+   $y?Visible=?6?    ? ColumnDefinitions 5      ?? 5      ?? 5       ? RowDefinitions 5      ?? 5      ?? 5      ?? 5      .+?5      ?? $	??Ime??6
   $
??Left=?6   $??
315,46,0,0q?64   $	??Top=?6H   $??35??6`   $??99??6l   $??2??6w   ?? 5      $??Prezime??6
   $
??Left=?6   $??302,104,0,0q?67   $	??Top=?6L   $??39??6d   $??99??6p   $??2??6{   ?? 5      $	??Tip??6
   $
??Left=?6   $??315,155,0,0q?63   $	??Top=?6H   $??99??6`   $??39??6k   $??2??6w   $??2??6?   ?? 5      $??Korisnicko Ime??6
   $
??Left=?6#   $??
268,79,0,0q?6>   $??1??6R   $	??Top=?6_   $??99??6w   $??37??6?   $??2??6?   ?? 5      $??Lozinka??6
   $
??Left=?6   $??291,133,0,0q?67   $??1??6L   $	??Top=?6Y   $??99??6q   $??39??6|   $??2??6?   ?? 5      $??Email??6
   $
??Left=?6   $??
291,10,0,0q?65   $??2??6I   $	??Top=?6V   $??99??6n   $??40??6y   $??2??6?   ?? 5      -   5        $??
imeTextBox??5       ?? 	MaxLength$ 25??6   $
??Left=?6-   $??23??6H   $??10.667,46,0,0q?6T   	 ?? TextWrapping$
	 Wrap=?6k   $	??Top=?6?   $	??120??6?   $??1??6?   ?? 5      -   5        $??prezimeTextBox??5      $ 25??6   $??1??61   $
??Left=?6A   $??23??6\   $??10.667,104,0,0q?6h   $
	 Wrap=?6?   $	??Top=?6?   $	??120??6?   ?? 5      -   5        $??tipComboBox??5      $??1??6    $
??Left=?60   $??10.667,157,0,0q?6K   $	??Top=?6c   $	??120??6{   .@?5       ?? -   5        $??AdminCbi??5       $??ADMIN??6"   ?? 5!      -   5        $??MusterijaCbi??5!      $??	MUSTERIJA??6&   ?? 5"      -   5        $??	RadnikCbi??5"      $??RADNIK??6#   
 ?? 
IsSelected
 . 64   5$      ?? 5&      -   5        $??korisnicko_imeTextBox??5&      $ 25??6   $??1??68   $
??Left=?6H   $??23??6c   $??10.667,78.667,0,0q?6o   $??1??6?   $
	 Wrap=?6?   $	??Top=?6?   $	??120??6?   ?? 5'      -	   5        $??lozinkaTextBox??5'      $ 25??6   $??1??61   $
??Left=?6A   $??23??6\   $??9.667,135.667,0,0q?6h   $??1??6?   $
	 Wrap=?6?   $	??Top=?6?   $	??120??6?   ?? 5(      -
   5        $??emailTextBox??5(      $ 50??6   $??1??60   $
??Left=?6@   $??23??6[   $??10.667,12,0,0q?6g   $??2??6~   $
	 Wrap=?6?   $	??Top=?6?   $	??120??6?   ?? 5)      -   5        $??	IzmeniBtn??5)      $??Izmeni??6   $??1??6-   $
??Left=?6=   $??
82,128,0,0q?6X   $??2??6l   $	??Top=?6y   $	??116??6?   $??36??6?   ??5*      ?? 5+       ?? 
TargetType" ??6    ?? 	Resources 5,      9  3SF52_2015.View.Converters.MyTextValidationConverter   MyTextValidationConverter??%   &	          5-      6(   5.      .?5/      ??  ?? Property ? {? ?? Value 50      `? 52   	    `? 	Converter# [  6   .1?53   
   ??  ?? Path$
 Text?6    ?? ElementName$ korisnicko_imeTextBox??6   ?? 54   
   $
 Text?6   $ 
imeTextBox??6   ?? 55   
   $
 Text?6   $ prezimeTextBox??6   ?? 56   
   $
 Text?6   $ lozinkaTextBox??6   ?? 57   
   $
 Text?6   $ emailTextBox??6   ?? 58   
   $
 Text?6   $ tipComboBox??6   59   
   5<      5=      5@      ?? 5B      -   5        $??	OtkaziBtn??5B      $??Otkazi??6   $
??Left=?6-   $??187,128,0,0q?6H   $??2??6]   $	??Top=?6j   $	??110??6?   $??36??6?   6?   5D      5G      