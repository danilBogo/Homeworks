.assembly Homework2.IL
{
  .ver 4:0:0:0
}

.class public abstract sealed auto ansi beforefieldinit
  Homework2.IL.Extensions
    extends [System.Runtime]System.Object
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.ExtensionAttribute::.ctor()
    = (01 00 00 00 )

  .method public hidebysig static bool
    TryParseToOperation(
      string operation,
      [out] valuetype Homework2.IL.Operations& result
    ) cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.ExtensionAttribute::.ctor()
      = (01 00 00 00 )
    .maxstack 2
    .locals init (
      [0] valuetype Homework2.IL.Operations V_0,
      [1] bool V_1,
      [2] bool V_2
    )
 
    ldarg.0     
    ldstr        "+"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Plus
    ldarg.0      
    ldstr        "-"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Minus
    ldarg.0      
    ldstr        "*"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Multiply
    ldarg.0     
    ldstr        "/"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Divide
    br.s         Unknown
 
    Plus: 
        ldc.i4.0
        stloc.0      
        br.s         ResultReceived

    Minus: 
        ldc.i4.1
        stloc.0      
        br.s         ResultReceived
 
    Multiply: 
        ldc.i4.2
        stloc.0      
        br.s         ResultReceived
    
    Divide: 
        ldc.i4.3
        stloc.0  
        br.s         ResultReceived
 
    Unknown: 
        ldc.i4.4
        stloc.0
        br.s         ResultReceived
        
    ResultReceived: 
        ldarg.1      
        ldloc.0      
        stind.i4
        ldarg.1     
        ldind.i4
        ldc.i4.4
        ceq 
        brtrue.s  InvalidOperation
        ldc.i4.1
        ret
        
    InvalidOperation:
        ldarg.0      
        ldstr        " is unknown operation!"
        call         string [System.Runtime]System.String::Concat(string, string)
        call         void [System.Console]System.Console::WriteLine(string)
        ldc.i4.0
        ret 
  } 
}