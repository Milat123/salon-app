   M S B A M L   `   `   `  ????D  @SF52-2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SF52_2015	SF52_2015  5   	       SF52_2015.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SF52_2015     5   	     ? Title$  Login??5   	   $	??450??6   $	??800??6$    ? WindowStartupLocation$ CenterScreen=?60   ??5	      ?? 5
       j? Stretch$
 Fill=?6    j? 
AlignmentY$	 Top=?6    j? 
AlignmentX$ Center=?6/    ?? ImageSource$% /SF52-2015;component/Salon2.jpg??6C   6s   .??5      ? .+?5   
   ?? $??Korisnicko Ime??6   $
??Left=?6)   $??31??6D   $??
265,56,0,0q?6P   $	??Top=?6d   $	??153??6|   ?? 5   
   -   5        $??KorisnickoImeTextBox??5   "    ?? 	MaxLength$ 25??6   $
??Left=?6?   $??31??6Z   $??
423,56,0,0q?6f    ?? TextWrapping$
 Wrap=?6z   $	??Top=?6?   $	??263??6?   .??6?   ??5      ?? 5       ?? Path$ korisnickoImeUnosPath?6   	 ?? Mode$	 OneWayToSource=?67   
 ?? UpdateSourceTrigger$
 PropertyChanged=?6M   5      .??5      5      ?? 5   
   $??Lozinka??6   $
??Left=?6"   $??33??6=   $??304,118,0,0q?6I   $	??Top=?6^   $	??153??6v   G? 5      -   5        $??LozinkaTextBox??5        G? 	MaxLength$ 25??6   $
??Left=?66   $??33??6Q   $??423,118,0,0q?6]   $	??Top=?6r   $	??263??6?   5      ?? 5      -   5        $??	Uloguj se??5      $
??Left=?6   $??563,232,0,0q?6:   $??44??6O   $	??Top=?6[   $??75??6s   6~   ?? 5      -   5        $??Otkazi??5      $
??Left=?6   $??44??67   $??386,232,0,0q?6C   $	??Top=?6X   $??88??6p   6{   5      5      