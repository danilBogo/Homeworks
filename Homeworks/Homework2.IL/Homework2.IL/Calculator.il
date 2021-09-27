.assembly Homework2.IL
{
  .ver 4:0:0:0
}
.class public sealed auto ansi
  Homework2.IL.Operations
    extends System.Enum
{
  .field public specialname rtspecialname int32 value__

  .field public static literal valuetype Homework2.IL.Operations Plus = int32(0) 

  .field public static literal valuetype Homework2.IL.Operations Minus = int32(1) 

  .field public static literal valuetype Homework2.IL.Operations Multiply = int32(2)

  .field public static literal valuetype Homework2.IL.Operations Divide = int32(3)

  .field public static literal valuetype Homework2.IL.Operations Unknown = int32(4)
}
.class public abstract sealed auto ansi beforefieldinit
  Homework2.IL.Calculator
    extends System.Object
{
  .method public hidebysig static float64
    Calculate(
      int32 val1,
      valuetype Homework2.IL.Operations operation,
      int32 val2
    ) cil managed
  {
    .maxstack 3
    ldarg.0
    conv.r8
    ldarg.2
    conv.r8
    ldarg.1
    switch (Plus, Minus, Multiply, Divide)
    Plus: add
    ret
    Minus: sub
    ret
    Multiply: mul
    ret
    Divide: div
    ret
  }
}