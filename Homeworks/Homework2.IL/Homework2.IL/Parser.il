.assembly Homework2.IL
{
  .ver 4:0:0:0
}

.class public abstract sealed auto ansi beforefieldinit
  Homework2.IL.Parser
    extends [System.Runtime]System.Object
{

  .method public hidebysig static bool
    TryParseArguments(
      string[] args,
      [out] int32& val1,
      [out] int32& val2
    ) cil managed
  {
    .maxstack 4
    .locals init (
      [0] bool isVal1Int,
      [1] bool isVal2Int,
      [2] bool V_2,
      [3] bool V_3
    )    
    
    ldarg.0      
    ldc.i4.0
    ldelem.ref
    ldarg.1      
    call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    brfalse.s    InvalidSyntax 
    ldarg.0      
    ldc.i4.2
    ldelem.ref
    ldarg.2      
    call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    brfalse.s    InvalidSyntax      
    ldc.i4.1
    ret
    
    InvalidSyntax:
        ldarg.0
        ldc.i4.0
        ldelem.ref
        
        ldarg.0
        ldc.i4.1
        ldelem.ref
        
        ldarg.0
        ldc.i4.2
        ldelem.ref
        
        ldstr        " is not a valid calculate syntax"
        call         string [System.Runtime]System.String::Concat(string, string, string, string)
        call void [System.Console]System.Console::WriteLine(string)
        ldc.i4.0
        ret 
  }
}