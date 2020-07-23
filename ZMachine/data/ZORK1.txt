Resident data ends at 4e37, program starts at 4f04, file ends at 14b8c

Starting analysis pass at address 4e37

End of analysis pass, low address = 4e38, high address = 10b04

[Start of code]

Routine R0001, 1 local (0000)

       PRINT           "a "
       PRINT_OBJ       L00
       RTRUE           

Routine R0002, 1 local (0000)

       JZ              G3c [TRUE] L0001
       RANDOM          #64 -> -(SP)
       JG              L00,(SP)+ [TRUE] RTRUE
       RFALSE          
L0001: RANDOM          #012c -> -(SP)
       JG              L00,(SP)+ [TRUE] RTRUE
       RFALSE          

Routine R0003, 1 local (0000)

       LOADW           L00,#00 -> -(SP)
       RANDOM          (SP)+ -> -(SP)
       LOADW           L00,(SP)+ -> -(SP)
       RET_POPPED      

Routine R0004, 6 locals (0000, 0000, 0000, 0000, 0000, 0000)

       LOADW           L00,#00 -> L01
       LOADW           L00,#01 -> L02
       DEC             L01
       ADD             L00,#02 -> L00
       MUL             L02,#02 -> -(SP)
       ADD             L00,(SP)+ -> L05
       SUB             L01,L02 -> -(SP)
       RANDOM          (SP)+ -> L03
       LOADW           L05,L03 -> L04
       LOADW           L05,#01 -> -(SP)
       STOREW          L05,L03,(SP)+
       STOREW          L05,#01,L04
       INC             L02
       JE              L02,L01 [FALSE] L0001
       STORE           L02,#00
L0001: STOREW          L00,#00,L02
       RET             L04

Routine R0005, 0 locals ()

       JE              G78,#2b [FALSE] RFALSE
       CALL            R0235 (#a3) -> -(SP)
       RFALSE          

Routine R0006, 0 locals ()

       JZ              G2e [TRUE] L0002
       TEST_ATTR       "grating",#0b [FALSE] L0001
       RET             #39
L0001: PRINT           "The grating is closed!"
       NEW_LINE        
       CALL            R0255 (#ae) -> -(SP)
       RFALSE          
L0002: PRINT           "You can't go that way."
       NEW_LINE        
       RFALSE          

Routine R0007, 1 local (0000)

       JE              L00,#01 [FALSE] RFALSE
       JE              G78,#45 [FALSE] RFALSE
       JZ              G76 [FALSE] RFALSE
       CALL            R0431 (S148) -> -(SP)
       RTRUE           

Main routine R0008, 0 locals ()

L0001: CALL            R0022 (#8010,#ffff) -> -(SP)
       STOREW          (SP)+,#00,#01
       CALL            R0022 (#807c,#ffff) -> -(SP)
       CALL            R0022 (#80f0,#ffff) -> -(SP)
       STOREW          (SP)+,#00,#01
       CALL            R0022 (#6f6a,#28) -> -(SP)
       CALL            R0022 (#6f55,#c8) -> -(SP)
       PUT_PROP        "magic boat",#06,#04
       ADD             G10,#02 -> -(SP)
       STOREW          G0a,#01,(SP)+
       ADD             G10,#04 -> -(SP)
       STOREW          G0a,#02,(SP)+
       ADD             G0e,#02 -> -(SP)
       STOREW          G09,#02,(SP)+
       ADD             G0e,#04 -> -(SP)
       STOREW          G09,#03,(SP)+
       ADD             G0d,#02 -> -(SP)
       STOREW          G08,#01,(SP)+
       ADD             G0c,#02 -> -(SP)
       STOREW          G08,#03,(SP)+
       STORE           G00,#b4
       CALL            R0255 (#a0) -> -(SP)
       TEST_ATTR       G00,#03 [TRUE] L0002
       CALL            R0077 -> -(SP)
       NEW_LINE        
L0002: STORE           G42,#01
       STORE           G6f,#04
       STORE           G80,G6f
       INSERT_OBJ      G6f,G00
       CALL            R0144 -> -(SP)
       CALL            R0025 -> -(SP)
       JUMP            L0001

Routine R0009, 3 locals (0000, 0001, 0000)

       JE              G76,#0b [FALSE] L0001
       JE              G77,#0b [FALSE] L0001
       PRINT_RET       "Those things aren't here!"
L0001: JE              G76,#0b [FALSE] L0002
       STORE           L00,G56
       JUMP            L0003
L0002: STORE           L00,G55
       STORE           L01,#00
L0003: STORE           G6c,#00
       STORE           G60,#00
       JE              G6f,G80 [FALSE] L0004
       PRINT           "You can't see any"
       CALL            R0012 (L01) -> -(SP)
       PRINT_RET       " here!"
L0004: PRINT           "The "
       PRINT_OBJ       G6f
       PRINT           " seems confused. "I don't see any"
       CALL            R0012 (L01) -> -(SP)
       PRINT_RET       " here!""

Routine R0010, 4 locals (0000, 0000, 0000, 0000)

       CALL            R0052 (L00) -> L02
       JG              L02,#01 [FALSE] L0001
       LOADW           L00,#01 -> -(SP)
       GET_PROP        (SP)+,#05 -> L03
       JZ              L03 [TRUE] L0001
       STORE           L02,#01
       STORE           G4c,L03
L0001: JE              #01,L02 [FALSE] L0003
       JZ              L01 [TRUE] L0002
       STORE           G76,G4c
       RFALSE          
L0002: STORE           G77,G4c
       RFALSE          
L0003: JZ              L01 [FALSE] L0004
       PRINT           "You wouldn't find any"
       CALL            R0012 (L01) -> -(SP)
       PRINT_RET       " there."
L0004: RET             #0b

Routine R0011, 1 local (0000)

       STORE           G6c,#00
       STORE           G60,#00
       PRINT           "You can't see any"
       JE              L00,G76 [FALSE] L0001
       CALL            R0064 -> -(SP)
       JUMP            L0002
L0001: CALL            R0065 -> -(SP)
L0002: PRINT_RET       " here."

Routine R0012, 2 locals (0000, 0000)

       JZ              G69 [TRUE] L0002
       JZ              G4a [TRUE] L0001
       PRINT           " "
       PRINT_ADDR      G49
L0001: JZ              G4b [TRUE] RFALSE
       PRINT           " "
       PRINT_ADDR      G4b
       RTRUE           
L0002: JZ              L00 [TRUE] L0003
       LOADW           G64,#06 -> L01
       LOADW           G64,#07 -> -(SP)
       CALL            R0040 (L01,(SP)+,#00) -> -(SP)
       RET_POPPED      
L0003: LOADW           G64,#08 -> L01
       LOADW           G64,#09 -> -(SP)
       CALL            R0040 (L01,(SP)+,#00) -> -(SP)
       RET_POPPED      

Routine R0013, 2 locals (0000, 0000)

       RFALSE          

Routine R0014, 0 locals ()

       JE              G78,#22 [FALSE] RFALSE
       PRINT_RET       "You should say whether you want to go up or down."

Routine R0015, 0 locals ()

       JE              G78,#42 [FALSE] RFALSE
       INC             G45
       CALL            R0013 -> -(SP)
       MOD             G45,#14 -> -(SP)
       JZ              (SP)+ [FALSE] L0001
       PRINT_RET       "You seem to be repeating yourself."
L0001: MOD             G45,#0a -> -(SP)
       JZ              (SP)+ [FALSE] L0002
       PRINT_RET       "I think that phrase is getting a bit worn out."
L0002: PRINT_RET       "Nothing happens here."

Routine R0016, 0 locals ()

       JE              G78,#32,#12 [FALSE] L0001
       JE              G77,#08 [FALSE] L0001
       CALL            R0026 (#31,G76) -> -(SP)
       RTRUE           
L0001: JE              G00,#7e [FALSE] L0002
       CALL            R0385 -> -(SP)
       RET_POPPED      
L0002: JE              G78,#2c [FALSE] RFALSE
       PRINT_RET       "The ground is too hard for digging here."

Routine R0017, 0 locals ()

       JE              G78,#38 [FALSE] L0001
       PRINT_RET       "The grue is a sinister, lurking presence in the dark
places of the earth. Its favorite diet is adventurers, but its insatiable
appetite is tempered by its fear of light. No grue has ever been seen by the
light of day, and few have survived its fearsome jaws to tell the tale."
L0001: JE              G78,#3c [FALSE] L0002
       PRINT_RET       "There is no grue here, but I'm sure there is at least
one lurking in the darkness nearby. I wouldn't let my light go out if I were
you!"
L0002: JE              G78,#4d [FALSE] RFALSE
       PRINT_RET       "It makes no sound but is always lurking in the darkness
nearby."

Routine R0018, 1 local (0000)

       JE              G78,#6f [FALSE] L0001
       STORE           G6c,#00
       STORE           G60,#00
       PRINT_RET       "Talking to yourself is said to be a sign of impending
mental collapse."
L0001: JE              G78,#3f [FALSE] L0002
       JE              G77,#05 [FALSE] L0002
       CALL            R0026 (#5d,G76) -> -(SP)
       RTRUE           
L0002: JE              G78,#56 [FALSE] L0003
       PRINT_RET       "Only you can do that."
L0003: JE              G78,#2d [FALSE] L0004
       PRINT_RET       "You'll have to do that on your own."
L0004: JE              G78,#33 [FALSE] L0005
       PRINT_RET       "Auto-cannibalism is not the answer."
L0005: JE              G78,#2a,#13 [FALSE] L0007
       JZ              G77 [TRUE] L0006
       TEST_ATTR       G77,#1d [FALSE] L0006
       CALL            R0431 (S164) -> -(SP)
       RET_POPPED      
L0006: PRINT_RET       "Suicide is not the answer."
L0007: JE              G78,#5d [FALSE] L0008
       PRINT_RET       "How romantic!"
L0008: JE              G78,#38 [FALSE] RFALSE
       GET_PARENT      "mirror" -> L00
       GET_PARENT      "mirror" -> -(SP)
       JE              G00,L00,(SP)+ [FALSE] L0009
       PRINT_RET       "Your image in the mirror looks tired."
L0009: PRINT_RET       "That's difficult unless your eyes are prehensile."

Routine R0019, 0 locals ()

       JE              G78,#3d,#5d [FALSE] L0001
       PRINT_RET       "You must specify a direction to go."
L0001: JE              G78,#3c [FALSE] L0002
       PRINT_RET       "I can't help you there...."
L0002: JE              G78,#2c [FALSE] RFALSE
       PRINT_RET       "Not a chance."

Routine R0020, 0 locals ()

       JE              G78,#38 [FALSE] L0001
       PRINT_RET       "The zorkmid is the unit of currency of the Great
Underground Empire."
L0001: JE              G78,#3c [FALSE] RFALSE
       PRINT_RET       "The best way to find zorkmids is to go out and look for
them."

Routine R0021, 3 locals (0000, 0000, 0000)

       CALL            R0023 (L00,#01) -> L02
       STOREW          L02,#01,L01
       RET             L02

Routine R0022, 3 locals (0000, 0000, 0000)

       CALL            R0023 (L00) -> L02
       STOREW          L02,#01,L01
       RET             L02

Routine R0023, 5 locals (0000, 0000, 0000, 0000, 0000)

       ADD             G84,#b4 -> L02
       ADD             G84,G82 -> L03
L0001: JE              L03,L02 [FALSE] L0003
       SUB             G82,#06 -> G82
       JZ              L01 [TRUE] L0002
       SUB             G83,#06 -> G83
L0002: ADD             G84,G82 -> L04
       STOREW          L04,#02,L00
       RET             L04
L0003: LOADW           L03,#02 -> -(SP)
       JE              (SP)+,L00 [FALSE] L0004
       RET             L03
L0004: ADD             L03,#06 -> L03
       JUMP            L0001

Routine R0024, 4 locals (0000, 0000, 0000, 0000)

       JZ              G81 [TRUE] L0001
       STORE           G81,#00
       RFALSE          
L0001: JZ              G7f [TRUE] L0002
       PUSH            G82
       JUMP            L0003
L0002: PUSH            G83
L0003: ADD             G84,(SP)+ -> L00
       ADD             G84,#b4 -> L01
L0004: JE              L00,L01 [FALSE] L0006
       INC_CHK         G02,#03e7 [FALSE] L0005
       STORE           G02,#00
L0005: RET             L03
L0006: LOADW           L00,#00 -> -(SP)
       JZ              (SP)+ [TRUE] L0008
       LOADW           L00,#01 -> L02
       JZ              L02 [FALSE] L0007
       JUMP            L0008
L0007: SUB             L02,#01 -> -(SP)
       STOREW          L00,#01,(SP)+
       JG              L02,#01 [TRUE] L0008
       LOADW           L00,#02 -> -(SP)
       CALL            (SP)+ -> -(SP)
       JZ              (SP)+ [TRUE] L0008
       STORE           L03,#01
L0008: ADD             L00,#06 -> L00
       JUMP            L0004

Routine R0025, 10 locals (0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000,
                          0000)

L0001: STORE           L03,#00
       STORE           L04,#00
       STORE           L07,#01
       CALL            R0027 -> G7f
       JZ              G7f [TRUE] L0039
       LOADW           G55,G51 -> L00
       LOADW           G56,G51 -> L01
       JZ              L01 [FALSE] L0002
       PUSH            L01
       JUMP            L0007
L0002: JG              L01,#01 [FALSE] L0005
       STORE           L05,G56
       JZ              L00 [FALSE] L0003
       STORE           L04,#00
       JUMP            L0004
L0003: LOADW           G55,#01 -> L04
L0004: PUSH            L01
       JUMP            L0007
L0005: JG              L00,#01 [FALSE] L0006
       STORE           L07,#00
       STORE           L05,G55
       LOADW           G56,#01 -> L04
       PUSH            L00
       JUMP            L0007
L0006: PUSH            #01
L0007: STORE           L02,(SP)+
       JZ              L04 [FALSE] L0008
       JE              L00,#01 [FALSE] L0008
       LOADW           G55,#01 -> L04
L0008: JE              G78,#89 [FALSE] L0009
       CALL            R0026 (G78,G76) -> L06
       JUMP            L0035
L0009: JZ              L02 [FALSE] L0012
       LOADB           G73,#00 -> -(SP)
       AND             (SP)+,#03 -> -(SP)
       JZ              (SP)+ [FALSE] L0010
       CALL            R0026 (G78) -> L06
       STORE           G76,#00
       JUMP            L0035
L0010: JZ              G42 [FALSE] L0011
       PRINT           "It's too dark to see."
       NEW_LINE        
       JUMP            L0035
L0011: PRINT           "It's not clear what you're referring to."
       NEW_LINE        
       STORE           L06,#00
       JUMP            L0035
L0012: STORE           G7a,#00
       STORE           G7b,#00
       JG              L02,#01 [FALSE] L0013
       STORE           G7b,#01
L0013: STORE           L09,#00
L0014: INC_CHK         L03,L02 [FALSE] L0020
       JG              G7a,#00 [FALSE] L0019
       PRINT           "The "
       JE              G7a,L02 [TRUE] L0015
       PRINT           "other "
L0015: PRINT           "object"
       JE              G7a,#01 [TRUE] L0016
       PRINT           "s"
L0016: PRINT           " that you mentioned "
       JE              G7a,#01 [TRUE] L0017
       PRINT           "are"
       JUMP            L0018
L0017: PRINT           "is"
L0018: PRINT           "n't here."
       NEW_LINE        
       JUMP            L0035
L0019: JZ              L09 [FALSE] L0035
       PRINT           "There's nothing here you can take."
       NEW_LINE        
       JUMP            L0035
L0020: JZ              L07 [TRUE] L0021
       LOADW           G56,L03 -> L08
       JUMP            L0022
L0021: LOADW           G55,L03 -> L08
L0022: JZ              L07 [TRUE] L0023
       PUSH            L08
       JUMP            L0024
L0023: PUSH            L04
L0024: STORE           G76,(SP)+
       JZ              L07 [TRUE] L0025
       PUSH            L04
       JUMP            L0026
L0025: PUSH            L08
L0026: STORE           G77,(SP)+
       JG              L02,#01 [TRUE] L0027
       LOADW           G64,#06 -> -(SP)
       LOADW           (SP)+,#00 -> -(SP)
       JE              (SP)+,"all" [FALSE] L0034
L0027: JE              L08,#0b [FALSE] L0028
       INC             G7a
       JUMP            L0014
L0028: JE              G78,#5d [FALSE] L0029
       JZ              G77 [TRUE] L0029
       LOADW           G64,#06 -> -(SP)
       LOADW           (SP)+,#00 -> -(SP)
       JE              (SP)+,"all" [FALSE] L0029
       JIN             G76,G77 [TRUE] L0029
       JUMP            L0014
L0029: JE              G50,#01 [FALSE] L0031
       JE              G78,#5d [FALSE] L0031
       GET_PARENT      L08 -> -(SP)
       JE              (SP)+,G6f,G00 [TRUE] L0030
       GET_PARENT      L08 -> -(SP)
       TEST_ATTR       (SP)+,#0a [FALSE] L0014
L0030: TEST_ATTR       L08,#11 [TRUE] L0031
       TEST_ATTR       L08,#0d [TRUE] L0031
       JUMP            L0014
L0031: JE              L08,#0c [FALSE] L0032
       PRINT_OBJ       G6b
       JUMP            L0033
L0032: PRINT_OBJ       L08
L0033: PRINT           ": "
L0034: STORE           L09,#01
       CALL            R0026 (G78,G76,G77) -> L06
       JE              L06,#02 [FALSE] L0014
       JUMP            L0035
L0035: JE              L06,#02 [TRUE] L0036
       GET_PARENT      G6f -> -(SP)
       GET_PROP        (SP)+,#11 -> -(SP)
       CALL            (SP)+ (#06) -> L06
L0036: JE              G78,#08,#89,#0f [TRUE] L0038
       JE              G78,#0c,#09,#07 [FALSE] L0037
       JUMP            L0038
L0037: STORE           G7e,G78
       STORE           G7d,G76
       STORE           G7c,G77
L0038: JE              L06,#02 [FALSE] L0040
       STORE           G6c,#00
       JUMP            L0040
L0039: STORE           G6c,#00
L0040: JZ              G7f [TRUE] L0001
       JE              G78,#02,#01,#6f [TRUE] L0001
       JE              G78,#0c,#08,#00 [TRUE] L0001
       JE              G78,#09,#06,#05 [TRUE] L0001
       JE              G78,#07,#0b,#0a [FALSE] L0041
       JUMP            L0001
L0041: CALL            R0024 -> L06
       JUMP            L0001

Routine R0026, 7 locals (0000, 0000, 0000, 0000, 0000, 0000, 0000)

       STORE           L04,G78
       STORE           L05,G76
       STORE           L06,G77
       JE              #0c,L02,L01 [FALSE] L0001
       JE              G6a,G00 [TRUE] L0001
       PRINT           "I don't see what you are referring to."
       NEW_LINE        
       RET             #02
L0001: JE              L01,#0c [FALSE] L0002
       STORE           L01,G6b
L0002: JE              L02,#0c [FALSE] L0003
       STORE           L02,G6b
L0003: STORE           G78,L00
       STORE           G76,L01
       JZ              G76 [TRUE] L0004
       JE              G77,#0c [TRUE] L0004
       JE              G78,#89 [TRUE] L0004
       STORE           G6b,G76
       STORE           G6a,G00
L0004: STORE           G77,L02
       JE              #0b,G76,G77 [FALSE] L0005
       CALL            R0009 -> L03
       JZ              L03 [TRUE] L0005
       JUMP            L0012
L0005: STORE           L01,G76
       STORE           L02,G77
       GET_PROP        G6f,#11 -> -(SP)
       CALL            (SP)+ -> L03
       JZ              L03 [TRUE] L0006
       JUMP            L0012
L0006: GET_PARENT      G6f -> -(SP)
       GET_PROP        (SP)+,#11 -> -(SP)
       CALL            (SP)+ (#01) -> L03
       JZ              L03 [TRUE] L0007
       JUMP            L0012
L0007: LOADW           G9c,L00 -> -(SP)
       CALL            (SP)+ -> L03
       JZ              L03 [TRUE] L0008
       JUMP            L0012
L0008: JZ              L02 [TRUE] L0009
       GET_PROP        L02,#11 -> -(SP)
       CALL            (SP)+ -> L03
       JZ              L03 [TRUE] L0009
       JUMP            L0012
L0009: JZ              L01 [TRUE] L0010
       JE              L00,#89 [TRUE] L0010
       GET_PARENT      L01 -> -(SP)
       JZ              (SP)+ [TRUE] L0010
       GET_PARENT      L01 -> -(SP)
       GET_PROP        (SP)+,#02 -> -(SP)
       CALL            (SP)+ -> L03
       JZ              L03 [TRUE] L0010
       JUMP            L0012
L0010: JZ              L01 [TRUE] L0011
       JE              L00,#89 [TRUE] L0011
       GET_PROP        L01,#11 -> -(SP)
       CALL            (SP)+ -> L03
       JZ              L03 [TRUE] L0011
       JUMP            L0012
L0011: LOADW           G9b,L00 -> -(SP)
       CALL            (SP)+ -> L03
       JZ              L03 [TRUE] L0012
L0012: STORE           G78,L04
       STORE           G76,L05
       STORE           G77,L06
       RET             L03

Routine R0027, 11 locals (0001, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000,
                          0000, ffff)

L0001: INC_CHK         L0a,#09 [FALSE] L0002
       JUMP            L0003
L0002: STOREW          G64,L0a,#00
       JUMP            L0001
L0003: STORE           G58,#00
       STORE           G68,#00
       STOREW          G56,G51,#00
       STOREW          G55,G51,#00
       STOREW          G54,G51,#00
       JZ              G60 [FALSE] L0005
       JE              G6f,G80 [TRUE] L0005
       STORE           G6f,G80
       GET_PARENT      G6f -> -(SP)
       TEST_ATTR       (SP)+,#1b [TRUE] L0004
       GET_PARENT      G6f -> G00
L0004: CALL            R0063 (G00) -> G42
L0005: JZ              G6c [TRUE] L0007
       STORE           L00,G6c
       JZ              G46 [FALSE] L0006
       JE              G80,G6f [FALSE] L0006
       JE              G78,#70 [TRUE] L0006
       NEW_LINE        
L0006: STORE           G6c,#00
       JUMP            L0010
L0007: STORE           G6f,G80
       STORE           G60,#00
       GET_PARENT      G6f -> -(SP)
       TEST_ATTR       (SP)+,#1b [TRUE] L0008
       GET_PARENT      G6f -> G00
L0008: CALL            R0063 (G00) -> G42
       JZ              G46 [FALSE] L0009
       NEW_LINE        
L0009: PRINT           ">"
       READ            G6d,G6e
L0010: LOADB           G6e,#01 -> G71
       JZ              G71 [FALSE] L0011
       PRINT           "I beg your pardon?"
       NEW_LINE        
       RFALSE          
L0011: STORE           L04,G71
       STORE           G70,#00
       STORE           G61,#00
       STORE           G50,#00
L0012: DEC_CHK         G71,#00 [FALSE] L0013
       STORE           G60,#00
       JUMP            L0040
L0013: LOADW           G6e,L00 -> L01
       JZ              L01 [FALSE] L0014
       CALL            R0030 (L00) -> L01
       JZ              L01 [TRUE] L0038
L0014: JE              L01,"to" [FALSE] L0015
       JE              L03,#ef [FALSE] L0015
       STORE           L01,"""
       JUMP            L0016
L0015: JE              L01,"then" [FALSE] L0016
       JZ              L03 [FALSE] L0016
       JZ              G60 [FALSE] L0016
       STOREW          G64,#00,#ef
       STOREW          G64,#01,#00
       STORE           L01,"""
L0016: JE              L01,"then","." [TRUE] L0017
       JE              L01,""" [FALSE] L0021
L0017: JE              L01,""" [FALSE] L0019
       JZ              G60 [TRUE] L0018
       STORE           G60,#00
       JUMP            L0019
L0018: STORE           G60,#01
L0019: JZ              G71 [TRUE] L0020
       ADD             L00,#02 -> G6c
L0020: STOREB          G6e,#01,G71
       JUMP            L0040
L0021: CALL            R0028 (L01,#10,#03) -> L02
       JZ              L02 [TRUE] L0027
       JE              L03,#00,#f8 [FALSE] L0027
       JE              L04,#01 [TRUE] L0025
       JE              L04,#02 [FALSE] L0022
       JE              L03,#f8 [TRUE] L0025
L0022: ADD             L00,#02 -> -(SP)
       LOADW           G6e,(SP)+ -> L06
       JE              L06,"then",".",""" [FALSE] L0023
       JL              L04,#02 [FALSE] L0025
L0023: JZ              G60 [TRUE] L0024
       JE              L04,#02 [FALSE] L0024
       JE              L06,""" [TRUE] L0025
L0024: JG              L04,#02 [FALSE] L0027
       JE              L06,",","and" [FALSE] L0027
L0025: STORE           L05,L02
       JE              L06,",","and" [FALSE] L0026
       ADD             L00,#02 -> -(SP)
       STOREW          G6e,(SP)+,"then"
L0026: JG              L04,#02 [TRUE] L0039
       STORE           G60,#00
       JUMP            L0040
L0027: CALL            R0028 (L01,#40,#01) -> L02
       JZ              L02 [TRUE] L0028
       JZ              L03 [FALSE] L0028
       STORE           L03,L02
       STOREW          G64,#00,L02
       STOREW          G64,#01,G62
       STOREW          G62,#00,L01
       MUL             L00,#02 -> -(SP)
       ADD             (SP)+,#02 -> L08
       LOADB           G6e,L08 -> -(SP)
       STOREB          G62,#02,(SP)+
       ADD             L08,#01 -> -(SP)
       LOADB           G6e,(SP)+ -> -(SP)
       STOREB          G62,#03,(SP)+
       JUMP            L0039
L0028: CALL            R0028 (L01,#08,#00) -> L02
       JZ              L02 [FALSE] L0030
       JE              L01,"all","one" [TRUE] L0029
       CALL            R0028 (L01,#20) -> -(SP)
       JZ              (SP)+ [FALSE] L0029
       CALL            R0028 (L01,#80) -> -(SP)
       JZ              (SP)+ [TRUE] L0035
L0029: STORE           L02,#00
L0030: JG              G71,#00 [FALSE] L0031
       ADD             L00,#02 -> -(SP)
       LOADW           G6e,(SP)+ -> -(SP)
       JE              (SP)+,"of" [FALSE] L0031
       JZ              L02 [FALSE] L0031
       JE              L01,"all","one","a" [TRUE] L0031
       JUMP            L0039
L0031: JZ              L02 [TRUE] L0033
       JZ              G71 [TRUE] L0032
       ADD             L00,#02 -> -(SP)
       LOADW           G6e,(SP)+ -> -(SP)
       JE              (SP)+,"then","." [FALSE] L0033
L0032: JL              G61,#02 [FALSE] L0039
       STOREW          G64,#02,L02
       STOREW          G64,#03,L01
       JUMP            L0039
L0033: JE              G61,#02 [FALSE] L0034
       PRINT           "There were too many nouns in that sentence."
       NEW_LINE        
       RFALSE          
L0034: INC             G61
       CALL            R0029 (L00,L02,L01) -> L00
       JZ              L00 [TRUE] RFALSE
       JL              L00,#00 [FALSE] L0039
       STORE           G60,#00
       JUMP            L0040
L0035: CALL            R0028 (L01,#04) -> -(SP)
       JZ              (SP)+ [TRUE] L0036
       JUMP            L0039
L0036: JE              L03,#ef [FALSE] L0037
       CALL            R0028 (L01,#40,#01) -> -(SP)
       JZ              (SP)+ [TRUE] L0037
       PRINT           "Please consult your manual for the correct way to talk
to other people or creatures."
       NEW_LINE        
       RFALSE          
L0037: CALL            R0035 (L00) -> -(SP)
       RFALSE          
L0038: CALL            R0034 (L00) -> -(SP)
       RFALSE          
L0039: STORE           L07,L01
       ADD             L00,#02 -> L00
       JUMP            L0012
L0040: JZ              L05 [TRUE] L0041
       STORE           G78,#89
       STORE           G76,L05
       STORE           G5f,L05
       RET             #01
L0041: STORE           G5f,#00
       JZ              G69 [TRUE] L0042
       CALL            R0031 -> -(SP)
L0042: CALL            R0036 -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       CALL            R0048 -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       CALL            R0060 -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       CALL            R0058 -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       RTRUE           

Routine R0028, 5 locals (0000, 0000, 0005, 0005, 0000)

       LOADB           L00,#04 -> L04
       TEST            L04,L01 [FALSE] RFALSE
       JG              L02,#04 [TRUE] RTRUE
       AND             L04,#03 -> L04
       JE              L04,L02 [TRUE] L0001
       INC             L03
L0001: LOADB           L00,L03 -> -(SP)
       RET_POPPED      

Routine R0029, 10 locals (0000, 0000, 0000, 0000, 0000, 0000, 0001, 0000, 0000,
                          0000)

       SUB             G61,#01 -> -(SP)
       MUL             (SP)+,#02 -> L03
       JZ              L01 [TRUE] L0001
       ADD             #02,L03 -> L04
       STOREW          G64,L04,L01
       ADD             L04,#01 -> -(SP)
       STOREW          G64,(SP)+,L02
       ADD             L00,#02 -> L00
       JUMP            L0002
L0001: INC             G71
L0002: JZ              G71 [FALSE] L0003
       DEC             G61
       RET             #ffff
L0003: ADD             #06,L03 -> L04
       MUL             L00,#02 -> -(SP)
       ADD             G6e,(SP)+ -> -(SP)
       STOREW          G64,L04,(SP)+
       LOADW           G6e,L00 -> -(SP)
       JE              (SP)+,"the","a","an" [FALSE] L0004
       LOADW           G64,L04 -> -(SP)
       ADD             (SP)+,#04 -> -(SP)
       STOREW          G64,L04,(SP)+
L0004: DEC_CHK         G71,#00 [FALSE] L0005
       ADD             L04,#01 -> L09
       MUL             L00,#02 -> -(SP)
       ADD             G6e,(SP)+ -> -(SP)
       STOREW          G64,L09,(SP)+
       RET             #ffff
L0005: LOADW           G6e,L00 -> L02
       JZ              L02 [FALSE] L0006
       CALL            R0030 (L00) -> L02
       JZ              L02 [TRUE] L0022
L0006: JZ              G71 [FALSE] L0007
       STORE           L07,#00
       JUMP            L0008
L0007: ADD             L00,#02 -> -(SP)
       LOADW           G6e,(SP)+ -> L07
L0008: JE              L02,"and","," [FALSE] L0009
       STORE           L05,#01
       JUMP            L0023
L0009: JE              L02,"all","one" [FALSE] L0010
       JE              L07,"of" [FALSE] L0023
       DEC             G71
       ADD             L00,#02 -> L00
       JUMP            L0023
L0010: JE              L02,"then","." [TRUE] L0011
       CALL            R0028 (L02,#08) -> -(SP)
       JZ              (SP)+ [TRUE] L0012
       LOADW           G64,#00 -> -(SP)
       JZ              (SP)+ [TRUE] L0012
       JZ              L06 [FALSE] L0012
L0011: INC             G71
       ADD             L04,#01 -> L09
       MUL             L00,#02 -> -(SP)
       ADD             G6e,(SP)+ -> -(SP)
       STOREW          G64,L09,(SP)+
       SUB             L00,#02 -> -(SP)
       RET             (SP)+
L0012: CALL            R0028 (L02,#80) -> -(SP)
       JZ              (SP)+ [TRUE] L0016
       JG              G71,#00 [FALSE] L0013
       JE              L07,"of" [FALSE] L0013
       JE              L02,"all","one" [TRUE] L0013
       JUMP            L0023
L0013: CALL            R0028 (L02,#20,#02) -> -(SP)
       JZ              (SP)+ [TRUE] L0014
       JZ              L07 [TRUE] L0014
       CALL            R0028 (L07,#80) -> -(SP)
       JZ              (SP)+ [TRUE] L0014
       JUMP            L0023
L0014: JZ              L05 [FALSE] L0015
       JE              L07,"but","except" [TRUE] L0015
       JE              L07,"and","," [TRUE] L0015
       ADD             L04,#01 -> L09
       ADD             L00,#02 -> -(SP)
       MUL             (SP)+,#02 -> -(SP)
       ADD             G6e,(SP)+ -> -(SP)
       STOREW          G64,L09,(SP)+
       RET             L00
L0015: STORE           L05,#00
       JUMP            L0023
L0016: JZ              G68 [FALSE] L0017
       JZ              G69 [FALSE] L0017
       LOADW           G64,#00 -> -(SP)
       JZ              (SP)+ [TRUE] L0018
L0017: CALL            R0028 (L02,#20) -> -(SP)
       JZ              (SP)+ [FALSE] L0023
       CALL            R0028 (L02,#04) -> -(SP)
       JZ              (SP)+ [TRUE] L0018
       JUMP            L0023
L0018: JZ              L05 [TRUE] L0020
       CALL            R0028 (L02,#10) -> -(SP)
       JZ              (SP)+ [FALSE] L0019
       CALL            R0028 (L02,#40) -> -(SP)
       JZ              (SP)+ [TRUE] L0020
L0019: SUB             L00,#04 -> L00
       ADD             L00,#02 -> -(SP)
       STOREW          G6e,(SP)+,"then"
       ADD             G71,#02 -> G71
       JUMP            L0023
L0020: CALL            R0028 (L02,#08) -> -(SP)
       JZ              (SP)+ [TRUE] L0021
       JUMP            L0023
L0021: CALL            R0035 (L00) -> -(SP)
       RFALSE          
L0022: CALL            R0034 (L00) -> -(SP)
       RFALSE          
L0023: STORE           L08,L02
       STORE           L06,#00
       ADD             L00,#02 -> L00
       JUMP            L0004

Routine R0030, 7 locals (0000, 0000, 0000, 0000, 0000, 0000, 0000)

       MUL             L00,#02 -> -(SP)
       ADD             G6e,(SP)+ -> -(SP)
       LOADB           (SP)+,#02 -> L01
       MUL             L00,#02 -> -(SP)
       ADD             G6e,(SP)+ -> -(SP)
       LOADB           (SP)+,#03 -> L02
L0001: DEC_CHK         L01,#00 [FALSE] L0002
       JUMP            L0005
L0002: LOADB           G6d,L02 -> L03
       JE              L03,#3a [FALSE] L0003
       STORE           L05,L04
       STORE           L04,#00
       JUMP            L0004
L0003: JG              L04,#2710 [TRUE] RFALSE
       JL              L03,#3a [FALSE] RFALSE
       JG              L03,#2f [FALSE] RFALSE
       MUL             L04,#0a -> L06
       SUB             L03,#30 -> -(SP)
       ADD             L06,(SP)+ -> L04
L0004: INC             L02
       JUMP            L0001
L0005: STOREW          G6e,L00,"intnum"
       JG              L04,#03e8 [TRUE] RFALSE
       JZ              L05 [TRUE] L0008
       JL              L05,#08 [FALSE] L0006
       ADD             L05,#0c -> L05
       JUMP            L0007
L0006: JG              L05,#17 [TRUE] RFALSE
L0007: MUL             L05,#3c -> -(SP)
       ADD             L04,(SP)+ -> L04
L0008: STORE           G5e,L04
       RET             "intnum"

Routine R0031, 8 locals (ffff, 0000, 0000, 0000, 0000, 0000, 0000, 0000)

       STORE           G69,#00
       LOADW           G64,#01 -> -(SP)
       LOADW           (SP)+,#00 -> -(SP)
       CALL            R0028 ((SP)+,#20,#02) -> -(SP)
       JZ              (SP)+ [TRUE] L0001
       STORE           L05,#01
L0001: LOADW           G64,#00 -> L02
       JZ              L02 [TRUE] L0002
       JZ              L05 [FALSE] L0002
       LOADW           G63,#00 -> -(SP)
       JE              L02,(SP)+ [FALSE] RFALSE
L0002: JE              G61,#02 [TRUE] RFALSE
       LOADW           G63,#06 -> -(SP)
       JE              (SP)+,#01 [FALSE] L0005
       LOADW           G64,#02 -> L01
       LOADW           G63,#02 -> -(SP)
       JE              L01,(SP)+ [TRUE] L0003
       JZ              L01 [FALSE] RFALSE
L0003: JZ              L05 [TRUE] L0004
       ADD             G6e,#02 -> -(SP)
       STOREW          G63,#06,(SP)+
       ADD             G6e,#06 -> -(SP)
       STOREW          G63,#07,(SP)+
       JUMP            L0018
L0004: LOADW           G64,#06 -> -(SP)
       STOREW          G63,#06,(SP)+
       LOADW           G64,#07 -> -(SP)
       STOREW          G63,#07,(SP)+
       JUMP            L0018
L0005: LOADW           G63,#08 -> -(SP)
       JE              (SP)+,#01 [FALSE] L0008
       LOADW           G64,#02 -> L01
       LOADW           G63,#04 -> -(SP)
       JE              L01,(SP)+ [TRUE] L0006
       JZ              L01 [FALSE] RFALSE
L0006: JZ              L05 [TRUE] L0007
       ADD             G6e,#02 -> -(SP)
       STOREW          G64,#06,(SP)+
       ADD             G6e,#06 -> -(SP)
       STOREW          G64,#07,(SP)+
L0007: LOADW           G64,#06 -> -(SP)
       STOREW          G63,#08,(SP)+
       LOADW           G64,#07 -> -(SP)
       STOREW          G63,#09,(SP)+
       STORE           G61,#02
       JUMP            L0018
L0008: JZ              G67 [TRUE] L0018
       JE              G61,#01 [TRUE] L0009
       JZ              L05 [FALSE] L0009
       STORE           G67,#00
       RFALSE          
L0009: LOADW           G64,#06 -> L03
       JZ              L05 [TRUE] L0010
       ADD             G6e,#02 -> L03
       STORE           L05,#00
L0010: LOADW           G64,#07 -> L04
L0011: LOADW           L03,#00 -> L06
       JE              L03,L04 [FALSE] L0013
       JZ              L05 [TRUE] L0012
       CALL            R0032 (L05) -> -(SP)
       JUMP            L0018
L0012: STORE           G67,#00
       RFALSE          
L0013: JZ              L05 [FALSE] L0015
       LOADB           L06,#04 -> -(SP)
       TEST            (SP)+,#20 [TRUE] L0014
       JE              L06,"all","one" [FALSE] L0015
L0014: STORE           L05,L06
       JUMP            L0017
L0015: LOADB           L06,#04 -> -(SP)
       TEST            (SP)+,#80 [TRUE] L0016
       JE              L06,"one" [FALSE] L0017
L0016: JE              L06,G66,"one" [FALSE] RFALSE
       CALL            R0032 (L05) -> -(SP)
       JUMP            L0018
L0017: ADD             L03,#04 -> L03
       JZ              L04 [FALSE] L0011
       STORE           L04,L03
       STORE           G61,#01
       SUB             L03,#04 -> -(SP)
       STOREW          G64,#06,(SP)+
       STOREW          G64,#07,L03
       JUMP            L0011
L0018: INC_CHK         L00,#09 [FALSE] L0019
       STORE           G68,#01
       RTRUE           
L0019: LOADW           G63,L00 -> -(SP)
       STOREW          G64,L00,(SP)+
       JUMP            L0018

Routine R0032, 1 local (0000)

       LOADW           G63,#00 -> -(SP)
       STOREW          G64,#00,(SP)+
       STORE           G72,G63
       ADD             G67,#01 -> -(SP)
       CALL            R0043 (G67,(SP)+,L00) -> -(SP)
       LOADW           G63,#08 -> -(SP)
       JZ              (SP)+ [TRUE] L0001
       STORE           G61,#02
L0001: STORE           G67,#00
       RTRUE           

Routine R0033, 2 locals (0000, 0000)

L0001: DEC_CHK         L00,#00 [TRUE] RTRUE
       LOADB           G6d,L01 -> -(SP)
       PRINT_CHAR      (SP)+
       INC             L01
       JUMP            L0001

Routine R0034, 3 locals (0000, 0000, 0000)

       JE              G78,#70 [FALSE] L0001
       PRINT           "Nothing happens."
       NEW_LINE        
       RFALSE          
L0001: PRINT           "I don't know the word ""
       MUL             L00,#02 -> L01
       ADD             G6e,L01 -> -(SP)
       LOADB           (SP)+,#02 -> L02
       ADD             G6e,L01 -> -(SP)
       LOADB           (SP)+,#03 -> -(SP)
       CALL            R0033 (L02,(SP)+) -> -(SP)
       PRINT           ""."
       NEW_LINE        
       STORE           G60,#00
       STORE           G69,#00
       RET             G69

Routine R0035, 3 locals (0000, 0000, 0000)

       JE              G78,#70 [FALSE] L0001
       PRINT           "Nothing happens."
       NEW_LINE        
       RFALSE          
L0001: PRINT           "You used the word ""
       MUL             L00,#02 -> L01
       ADD             G6e,L01 -> -(SP)
       LOADB           (SP)+,#02 -> L02
       ADD             G6e,L01 -> -(SP)
       LOADB           (SP)+,#03 -> -(SP)
       CALL            R0033 (L02,(SP)+) -> -(SP)
       PRINT           "" in a way that I don't understand."
       NEW_LINE        
       STORE           G60,#00
       STORE           G69,#00
       RET             G69

Routine R0036, 11 locals (0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000,
                          0000, 0000)

       LOADW           G64,#00 -> L07
       JZ              L07 [FALSE] L0001
       PRINT           "There was no verb in that sentence!"
       NEW_LINE        
       RFALSE          
L0001: SUB             #ff,L07 -> -(SP)
       LOADW           G9d,(SP)+ -> L00
       LOADB           L00,#00 -> L01
       ADD             #01,L00 -> L00
L0002: LOADB           L00,#00 -> -(SP)
       AND             (SP)+,#03 -> L02
       JG              G61,L02 [FALSE] L0003
       JUMP            L0007
L0003: JL              L02,#01 [TRUE] L0005
       JZ              G61 [FALSE] L0005
       LOADW           G64,#02 -> L06
       JZ              L06 [TRUE] L0004
       LOADB           L00,#01 -> -(SP)
       JE              L06,(SP)+ [FALSE] L0005
L0004: STORE           L04,L00
       JUMP            L0007
L0005: LOADB           L00,#01 -> L0a
       LOADW           G64,#02 -> -(SP)
       JE              L0a,(SP)+ [FALSE] L0007
       JE              L02,#02 [FALSE] L0006
       JE              G61,#01 [FALSE] L0006
       STORE           L05,L00
       JUMP            L0007
L0006: LOADB           L00,#02 -> L0a
       LOADW           G64,#04 -> -(SP)
       JE              L0a,(SP)+ [FALSE] L0007
       CALL            R0046 (L00) -> -(SP)
       RTRUE           
L0007: DEC_CHK         L01,#01 [FALSE] L0009
       JZ              L04 [FALSE] L0010
       JZ              L05 [TRUE] L0008
       JUMP            L0010
L0008: PRINT           "That sentence isn't one I recognize."
       NEW_LINE        
       RFALSE          
L0009: ADD             L00,#08 -> L00
       JUMP            L0002
L0010: JZ              L04 [TRUE] L0011
       LOADB           L04,#03 -> L09
       LOADB           L04,#05 -> L0a
       LOADB           L04,#01 -> -(SP)
       CALL            R0047 (L09,L0a,(SP)+) -> L03
       JZ              L03 [TRUE] L0011
       STOREW          G56,G51,#01
       STOREW          G56,#01,L03
       CALL            R0046 (L04) -> -(SP)
       RET_POPPED      
L0011: JZ              L05 [TRUE] L0012
       LOADB           L05,#04 -> L09
       LOADB           L05,#06 -> L0a
       LOADB           L05,#02 -> -(SP)
       CALL            R0047 (L09,L0a,(SP)+) -> L03
       JZ              L03 [TRUE] L0012
       STOREW          G55,G51,#01
       STOREW          G55,#01,L03
       CALL            R0046 (L05) -> -(SP)
       RET_POPPED      
L0012: JE              L07,#ac [FALSE] L0013
       PRINT           "That question can't be answered."
       NEW_LINE        
       RFALSE          
L0013: JE              G6f,G80 [TRUE] L0014
       CALL            R0037 -> -(SP)
       RET_POPPED      
L0014: CALL            R0038 (L04,L05) -> -(SP)
       PRINT           "What do you want to "
       LOADW           G63,#01 -> L08
       JZ              L08 [FALSE] L0015
       PRINT           "tell"
       JUMP            L0017
L0015: LOADB           G62,#02 -> -(SP)
       JZ              (SP)+ [FALSE] L0016
       LOADW           L08,#00 -> -(SP)
       PRINT_ADDR      (SP)+
       JUMP            L0017
L0016: LOADB           L08,#02 -> L0a
       LOADB           L08,#03 -> -(SP)
       CALL            R0033 (L0a,(SP)+) -> -(SP)
       STOREB          G62,#02,#00
L0017: JZ              L05 [TRUE] L0018
       CALL            R0039 (#06,#07) -> -(SP)
L0018: STORE           G69,#01
       JZ              L04 [TRUE] L0019
       LOADB           L04,#01 -> -(SP)
       JUMP            L0020
L0019: LOADB           L05,#02 -> -(SP)
L0020: CALL            R0042 ((SP)+) -> -(SP)
       PRINT           "?"
       NEW_LINE        
       RFALSE          

Routine R0037, 0 locals ()

       PRINT           ""I don't understand! What are you referring to?""
       NEW_LINE        
       RFALSE          

Routine R0038, 3 locals (0000, 0000, ffff)

       STOREW          G52,G51,#00
       STORE           G72,G64
L0001: INC_CHK         L02,#09 [FALSE] L0002
       JUMP            L0003
L0002: LOADW           G64,L02 -> -(SP)
       STOREW          G63,L02,(SP)+
       JUMP            L0001
L0003: JE              G61,#02 [FALSE] L0004
       CALL            R0043 (#08,#09) -> -(SP)
L0004: JL              G61,#01 [TRUE] L0005
       CALL            R0043 (#06,#07) -> -(SP)
L0005: JZ              L00 [TRUE] L0006
       LOADB           L00,#01 -> -(SP)
       STOREW          G63,#02,(SP)+
       STOREW          G63,#06,#01
       RTRUE           
L0006: JZ              L01 [TRUE] RFALSE
       LOADB           L01,#02 -> -(SP)
       STOREW          G63,#04,(SP)+
       STOREW          G63,#08,#01
       RTRUE           

Routine R0039, 4 locals (0000, 0000, 0001, 0000)

       LOADW           G64,L00 -> L03
       LOADW           G64,L01 -> -(SP)
       CALL            R0040 (L03,(SP)+,L02) -> -(SP)
       RET_POPPED      

Routine R0040, 8 locals (0000, 0000, 0000, 0000, 0000, 0001, 0000, 0000)

L0001: JE              L00,L01 [TRUE] RTRUE
       JZ              L03 [TRUE] L0002
       STORE           L03,#00
       JUMP            L0003
L0002: PRINT           " "
L0003: LOADW           L00,#00 -> L04
       JE              L04,"." [FALSE] L0004
       STORE           L03,#01
       JUMP            L0010
L0004: JZ              L05 [TRUE] L0005
       JZ              L06 [FALSE] L0005
       JZ              L02 [TRUE] L0005
       PRINT           "the "
L0005: JZ              G69 [FALSE] L0006
       JZ              G68 [TRUE] L0007
L0006: PRINT_ADDR      L04
       JUMP            L0009
L0007: JE              L04,"it" [FALSE] L0008
       JE              G6a,G00 [FALSE] L0008
       PRINT_OBJ       G6b
       JUMP            L0009
L0008: LOADB           L00,#02 -> L07
       LOADB           L00,#03 -> -(SP)
       CALL            R0033 (L07,(SP)+) -> -(SP)
L0009: STORE           L05,#00
L0010: ADD             L00,#04 -> L00
       JUMP            L0001

Routine R0041, 2 locals (0000, 0000)

       LOADB           L00,#03 -> -(SP)
       LOADB           G6d,(SP)+ -> -(SP)
       SUB             (SP)+,#20 -> -(SP)
       PRINT_CHAR      (SP)+
       LOADB           L00,#02 -> -(SP)
       SUB             (SP)+,#01 -> L01
       LOADB           L00,#03 -> -(SP)
       ADD             (SP)+,#01 -> -(SP)
       CALL            R0033 (L01,(SP)+) -> -(SP)
       RET_POPPED      

Routine R0042, 2 locals (0000, 0000)

       JZ              L00 [TRUE] RFALSE
       PRINT           " "
       CALL            R0045 (L00) -> L01
       PRINT_ADDR      L01
       RTRUE           

Routine R0043, 5 locals (0000, 0000, 0000, 0000, 0000)

       LOADW           G72,L00 -> L03
       LOADW           G72,L01 -> L04
       LOADW           G52,G51 -> -(SP)
       MUL             (SP)+,#02 -> -(SP)
       ADD             (SP)+,#02 -> -(SP)
       ADD             G52,(SP)+ -> -(SP)
       STOREW          G63,L00,(SP)+
L0001: JE              L03,L04 [FALSE] L0002
       LOADW           G52,G51 -> -(SP)
       MUL             (SP)+,#02 -> -(SP)
       ADD             (SP)+,#02 -> -(SP)
       ADD             G52,(SP)+ -> -(SP)
       STOREW          G63,L01,(SP)+
       RTRUE           
L0002: JZ              L02 [TRUE] L0003
       LOADW           L03,#00 -> -(SP)
       JE              G66,(SP)+ [FALSE] L0003
       CALL            R0044 (L02) -> -(SP)
L0003: LOADW           L03,#00 -> -(SP)
       CALL            R0044 ((SP)+) -> -(SP)
       ADD             L03,#04 -> L03
       JUMP            L0001

Routine R0044, 2 locals (0000, 0000)

       LOADW           G52,G51 -> -(SP)
       ADD             (SP)+,#02 -> L01
       SUB             L01,#01 -> -(SP)
       STOREW          G52,(SP)+,L00
       STOREW          G52,L01,#00
       STOREW          G52,G51,L01
       RTRUE           

Routine R0045, 3 locals (0000, 0000, 0000)

       LOADW           G9a,#00 -> -(SP)
       MUL             (SP)+,#02 -> L02
L0001: INC_CHK         L01,L02 [TRUE] RFALSE
       LOADW           G9a,L01 -> -(SP)
       JE              (SP)+,L00 [FALSE] L0001
       SUB             L01,#01 -> -(SP)
       LOADW           G9a,(SP)+ -> -(SP)
       RET             (SP)+

Routine R0046, 1 local (0000)

       STORE           G73,L00
       LOADB           L00,#07 -> G78
       RET             G78

Routine R0047, 4 locals (0000, 0000, 0000, 0000)

       JE              L00,#12 [FALSE] L0001
       RET             #52
L0001: STORE           G5b,L00
       STORE           G5c,L01
       STOREW          G53,G51,#00
       CALL            R0051 (G53,#00) -> -(SP)
       JZ              (SP)+ [TRUE] L0006
       STORE           G5b,#00
       LOADW           G53,G51 -> -(SP)
       JE              (SP)+,#01 [FALSE] RFALSE
       LOADW           G53,#01 -> L03
       JE              L03,#05 [TRUE] RFALSE
       PRINT           "("
       JZ              L02 [TRUE] L0004
       CALL            R0045 (L02) -> L02
       PRINT_ADDR      L02
       JE              L02,"out" [FALSE] L0002
       PRINT           " of"
L0002: JE              L03,#01 [FALSE] L0003
       PRINT           " your hands)"
       NEW_LINE        
       JUMP            L0004
L0003: PRINT           " the "
L0004: JE              L03,#01 [TRUE] L0005
       PRINT_OBJ       L03
       PRINT           ")"
       NEW_LINE        
L0005: RET             L03
L0006: STORE           G5b,#00
       RFALSE          

Routine R0048, 1 local (0000)

       LOADW           G64,#06 -> L00
       JZ              L00 [TRUE] L0001
       LOADB           G73,#05 -> G5c
       LOADW           G64,#07 -> -(SP)
       CALL            R0050 (L00,(SP)+,G56) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       LOADW           G54,G51 -> -(SP)
       JZ              (SP)+ [TRUE] L0001
       CALL            R0049 (G56) -> G56
L0001: LOADW           G64,#08 -> L00
       JZ              L00 [TRUE] RTRUE
       LOADB           G73,#06 -> G5c
       LOADW           G64,#09 -> -(SP)
       CALL            R0050 (L00,(SP)+,G55) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       LOADW           G54,G51 -> -(SP)
       JZ              (SP)+ [TRUE] RTRUE
       LOADW           G55,G51 -> -(SP)
       JE              (SP)+,#01 [FALSE] L0002
       CALL            R0049 (G56) -> G56
       RTRUE           
L0002: CALL            R0049 (G55) -> G55
       RTRUE           

Routine R0049, 7 locals (0000, 0000, 0000, 0001, 0000, 0000, 0000)

       LOADW           L00,G51 -> L01
       STOREW          G53,G51,#00
L0001: DEC_CHK         L01,#00 [FALSE] L0002
       JUMP            L0005
L0002: LOADW           L00,L03 -> L05
       CALL            R0061 (L05,G54) -> -(SP)
       JZ              (SP)+ [TRUE] L0003
       JUMP            L0004
L0003: ADD             L04,#01 -> -(SP)
       STOREW          G53,(SP)+,L05
       INC             L04
L0004: INC             L03
       JUMP            L0001
L0005: STOREW          G53,G51,L04
       STORE           L06,G53
       STORE           G53,L00
       RET             L06

Routine R0050, 8 locals (0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000)

       STORE           G50,#00
       STORE           G4f,L00
       STORE           G4e,L01
       STORE           G4d,#00
       STOREW          G54,G51,#00
       STOREW          L02,G51,#00
       LOADW           L00,#00 -> L06
L0001: JE              L00,L01 [FALSE] L0004
       JZ              L03 [TRUE] L0002
       PUSH            L03
       JUMP            L0003
L0002: PUSH            L02
L0003: CALL            R0051 ((SP)+) -> -(SP)
       RET             (SP)+
L0004: LOADW           L00,#02 -> L07
       JE              L06,"all" [FALSE] L0005
       STORE           G50,#01
       JE              L07,"of" [FALSE] L0020
       ADD             L00,#04 -> L00
       JUMP            L0020
L0005: JE              L06,"but","except" [FALSE] L0008
       JZ              L03 [TRUE] L0006
       PUSH            L03
       JUMP            L0007
L0006: PUSH            L02
L0007: CALL            R0051 ((SP)+) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       STORE           L03,G54
       STOREW          L03,G51,#00
       JUMP            L0020
L0008: JE              L06,"a","one" [FALSE] L0012
       JZ              G59 [FALSE] L0009
       STORE           G50,#02
       JE              L07,"of" [FALSE] L0020
       ADD             L00,#04 -> L00
       JUMP            L0020
L0009: STORE           G5a,G74
       JZ              L03 [TRUE] L0010
       PUSH            L03
       JUMP            L0011
L0010: PUSH            L02
L0011: CALL            R0051 ((SP)+) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       JZ              L07 [TRUE] RTRUE
       JUMP            L0020
L0012: JE              L06,"and","," [FALSE] L0015
       JE              L07,"and","," [TRUE] L0015
       STORE           G4d,#01
       JZ              L03 [TRUE] L0013
       PUSH            L03
       JUMP            L0014
L0013: PUSH            L02
L0014: CALL            R0051 ((SP)+) -> -(SP)
       JZ              (SP)+ [FALSE] L0020
       RFALSE          
L0015: CALL            R0028 (L06,#04) -> -(SP)
       JZ              (SP)+ [TRUE] L0016
       JUMP            L0020
L0016: JE              L06,"and","," [FALSE] L0017
       JUMP            L0020
L0017: JE              L06,"of" [FALSE] L0018
       JZ              G50 [FALSE] L0020
       STORE           G50,#04
       JUMP            L0020
L0018: CALL            R0028 (L06,#20,#02) -> L05
       JZ              L05 [TRUE] L0019
       JZ              G59 [FALSE] L0019
       STORE           G59,L05
       STORE           G57,L06
       JUMP            L0020
L0019: CALL            R0028 (L06,#80,#00) -> -(SP)
       JZ              (SP)+ [TRUE] L0020
       STORE           G5a,L06
       STORE           G74,L06
L0020: JE              L00,L01 [TRUE] L0001
       ADD             L00,#04 -> L00
       STORE           L06,L07
       JUMP            L0001

Routine R0051, 9 locals (0000, 0001, 0000, 0000, 0000, 0000, 0000, 0000, 0000)

       STORE           L04,G5c
       LOADW           L00,G51 -> L05
       TEST            G50,#04 [TRUE] RTRUE
       JZ              G5a [FALSE] L0001
       JZ              G59 [TRUE] L0001
       CALL            R0028 (G57,#80,#00) -> -(SP)
       JZ              (SP)+ [TRUE] L0001
       STORE           G5a,G57
       STORE           G59,#00
L0001: JZ              G5a [FALSE] L0002
       JZ              G59 [FALSE] L0002
       JE              G50,#01 [TRUE] L0002
       JZ              G5b [FALSE] L0002
       JZ              L01 [TRUE] RFALSE
       PRINT           "There seems to be a noun missing in that sentence!"
       NEW_LINE        
       RFALSE          
L0002: JE              G50,#01 [FALSE] L0003
       JZ              G5c [FALSE] L0004
L0003: STORE           G5c,#ffff
L0004: STORE           G75,L00
L0005: JZ              L06 [TRUE] L0006
       CALL            R0054 (L00) -> -(SP)
       JUMP            L0008
L0006: JZ              G42 [TRUE] L0007
       CLEAR_ATTR      G80,#0c
       CALL            R0055 (G00,#10,#20) -> -(SP)
       SET_ATTR        G80,#0c
L0007: CALL            R0055 (G80,#80,#40) -> -(SP)
L0008: LOADW           L00,G51 -> -(SP)
       SUB             (SP)+,L05 -> L03
       TEST            G50,#01 [FALSE] L0009
       JUMP            L0024
L0009: TEST            G50,#02 [FALSE] L0011
       JZ              L03 [TRUE] L0011
       JE              L03,#01 [TRUE] L0010
       RANDOM          L03 -> -(SP)
       LOADW           L00,(SP)+ -> -(SP)
       STOREW          L00,#01,(SP)+
       PRINT           "(How about the "
       LOADW           L00,#01 -> -(SP)
       PRINT_OBJ       (SP)+
       PRINT           "?)"
       NEW_LINE        
L0010: STOREW          L00,G51,#01
       JUMP            L0024
L0011: JG              L03,#01 [TRUE] L0012
       JZ              L03 [FALSE] L0020
       JE              G5c,#ffff [TRUE] L0020
L0012: JE              G5c,#ffff [FALSE] L0013
       STORE           G5c,L04
       STORE           L07,L03
       LOADW           L00,G51 -> -(SP)
       SUB             (SP)+,L03 -> -(SP)
       STOREW          L00,G51,(SP)+
       JUMP            L0005
L0013: JZ              L03 [FALSE] L0014
       STORE           L03,L07
L0014: JE              G6f,G80 [TRUE] L0015
       CALL            R0037 -> -(SP)
       RFALSE          
L0015: JZ              L01 [TRUE] L0018
       JZ              G5a [TRUE] L0018
       CALL            R0053 (L05,L03,L00) -> -(SP)
       JE              L00,G56 [FALSE] L0016
       PUSH            #06
       JUMP            L0017
L0016: PUSH            #08
L0017: STORE           G67,(SP)+
       STORE           G65,G59
       STORE           G66,G5a
       CALL            R0038 (#00,#00) -> -(SP)
       STORE           G69,#01
       JUMP            L0019
L0018: JZ              L01 [TRUE] L0019
       PRINT           "There seems to be a noun missing in that sentence!"
       NEW_LINE        
L0019: STORE           G5a,#00
       STORE           G59,#00
       RFALSE          
L0020: JZ              L03 [FALSE] L0023
       JZ              L06 [TRUE] L0023
       JZ              L01 [TRUE] L0022
       JZ              G42 [TRUE] L0021
       CALL            R0057 (#0b,L00) -> -(SP)
       STORE           G4b,G5a
       STORE           G4a,G59
       STORE           G49,G57
       STORE           G5a,#00
       STORE           G59,#00
       STORE           G57,#00
       RTRUE           
L0021: PRINT           "It's too dark to see!"
       NEW_LINE        
L0022: STORE           G5a,#00
       STORE           G59,#00
       RFALSE          
L0023: JZ              L03 [FALSE] L0024
       STORE           L06,#01
       JUMP            L0005
L0024: STORE           G5c,L04
       STORE           G5a,#00
       STORE           G59,#00
       RTRUE           

Routine R0052, 3 locals (0000, 0000, 0000)

       STORE           G5c,#ffff
       STORE           G5a,G4b
       STORE           G59,G4a
       STOREW          L00,G51,#00
       GET_CHILD       #52 -> L01 [TRUE] L0001
L0001: JZ              L01 [FALSE] L0002
       JUMP            L0004
L0002: CALL            R0056 (L01,L00,#01) -> -(SP)
       GET_SIBLING     L01 -> L01 [TRUE] L0003
L0003: JUMP            L0001
L0004: LOADW           L00,G51 -> L02
       JZ              L02 [FALSE] L0005
       CALL            R0055 (#f9,#01,#01) -> -(SP)
L0005: LOADW           L00,G51 -> L02
       JZ              L02 [FALSE] L0006
       CALL            R0055 (#52,#01,#01) -> -(SP)
L0006: LOADW           L00,G51 -> L02
       JE              L02,#01 [FALSE] L0007
       LOADW           L00,#01 -> G4c
L0007: STORE           G5a,#00
       STORE           G59,#00
       RET             L02

Routine R0053, 5 locals (0000, 0000, 0000, 0000, 0000)

       STORE           L04,L01
       PRINT           "Which"
       JZ              G69 [FALSE] L0001
       JZ              G68 [FALSE] L0001
       JZ              G4d [TRUE] L0002
L0001: PRINT           " "
       PRINT_ADDR      G5a
       JUMP            L0004
L0002: JE              L02,G56 [FALSE] L0003
       CALL            R0039 (#06,#07,#00) -> -(SP)
       JUMP            L0004
L0003: CALL            R0039 (#08,#09,#00) -> -(SP)
L0004: PRINT           " do you mean, "
L0005: INC             L00
       LOADW           L02,L00 -> L03
       PRINT           "the "
       PRINT_OBJ       L03
       JE              L01,#02 [FALSE] L0007
       JE              L04,#02 [TRUE] L0006
       PRINT           ","
L0006: PRINT           " or "
       JUMP            L0008
L0007: JG              L01,#02 [FALSE] L0008
       PRINT           ", "
L0008: DEC_CHK         L01,#01 [FALSE] L0005
       PRINT_RET       "?"

Routine R0054, 8 locals (0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000)

       LOADW           L00,G51 -> L01
       STORE           L06,G5c
       GET_PROP_ADDR   G00,#05 -> L02
       JZ              L02 [TRUE] L0003
       GET_PROP_LEN    L02 -> -(SP)
       SUB             (SP)+,#01 -> L03
L0001: LOADB           L02,L04 -> L05
       CALL            R0066 (L05,L00) -> -(SP)
       JZ              (SP)+ [TRUE] L0002
       CALL            R0057 (L05,L00) -> -(SP)
L0002: INC_CHK         L04,L03 [FALSE] L0001
L0003: GET_PROP_ADDR   G00,#04 -> L02
       JZ              L02 [TRUE] L0006
       GET_PROP_LEN    L02 -> -(SP)
       DIV             (SP)+,#04 -> -(SP)
       SUB             (SP)+,#01 -> L03
       STORE           L04,#00
L0004: MUL             L04,#02 -> -(SP)
       LOADW           L02,(SP)+ -> -(SP)
       JE              G5a,(SP)+ [FALSE] L0005
       MUL             L04,#02 -> -(SP)
       ADD             (SP)+,#01 -> -(SP)
       LOADW           L02,(SP)+ -> -(SP)
       PUT_PROP        "pseudo",#11,(SP)+
       GET_PROP_ADDR   "pseudo",#11 -> -(SP)
       SUB             (SP)+,#05 -> L07
       LOADW           G5a,#00 -> -(SP)
       STOREW          L07,#00,(SP)+
       LOADW           G5a,#01 -> -(SP)
       STOREW          L07,#01,(SP)+
       CALL            R0057 (#0d,L00) -> -(SP)
       JUMP            L0006
L0005: INC_CHK         L04,L03 [FALSE] L0004
L0006: LOADW           L00,G51 -> -(SP)
       JE              (SP)+,L01 [FALSE] RFALSE
       STORE           G5c,#ffff
       STORE           G75,L00
       CALL            R0055 (#f7,#01,#01) -> -(SP)
       STORE           G5c,L06
       LOADW           L00,G51 -> -(SP)
       JZ              (SP)+ [FALSE] RFALSE
       JE              G78,#39,#71,#38 [FALSE] RFALSE
       CALL            R0055 (#52,#01,#01) -> -(SP)
       RET_POPPED      

Routine R0055, 4 locals (0000, 0000, 0000, 0000)

       ADD             L01,L02 -> -(SP)
       TEST            G5c,(SP)+ [FALSE] L0001
       CALL            R0056 (L00,G75,#01) -> -(SP)
       RET_POPPED      
L0001: TEST            G5c,L01 [FALSE] L0002
       CALL            R0056 (L00,G75,#00) -> -(SP)
       RET_POPPED      
L0002: TEST            G5c,L02 [FALSE] RTRUE
       CALL            R0056 (L00,G75,#02) -> -(SP)
       RET_POPPED      

Routine R0056, 5 locals (0000, 0000, 0000, 0000, 0000)

       GET_CHILD       L00 -> L00 [FALSE] RFALSE
L0001: JE              L02,#02 [TRUE] L0002
       GET_PROP_ADDR   L00,#12 -> -(SP)
       JZ              (SP)+ [TRUE] L0002
       CALL            R0066 (L00,L01) -> -(SP)
       JZ              (SP)+ [TRUE] L0002
       CALL            R0057 (L00,L01) -> -(SP)
L0002: JE              L02,#00 [FALSE] L0003
       TEST_ATTR       L00,#08 [TRUE] L0003
       TEST_ATTR       L00,#0a [FALSE] L0008
L0003: GET_CHILD       L00 -> L04 [FALSE] L0008
       TEST_ATTR       L00,#0b [TRUE] L0004
       TEST_ATTR       L00,#0c [FALSE] L0008
L0004: TEST_ATTR       L00,#0a [FALSE] L0005
       PUSH            #01
       JUMP            L0007
L0005: TEST_ATTR       L00,#08 [FALSE] L0006
       PUSH            #01
       JUMP            L0007
L0006: PUSH            #00
L0007: CALL            R0056 (L00,L01,(SP)+) -> L03
L0008: GET_SIBLING     L00 -> L00 [TRUE] L0001
       RTRUE           

Routine R0057, 3 locals (0000, 0000, 0000)

       LOADW           L01,G51 -> L02
       ADD             L02,#01 -> -(SP)
       STOREW          L01,(SP)+,L00
       ADD             L02,#01 -> -(SP)
       STOREW          L01,G51,(SP)+
       RTRUE           

Routine R0058, 0 locals ()

       LOADB           G73,#05 -> -(SP)
       CALL            R0059 (G56,(SP)+) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       LOADB           G73,#06 -> -(SP)
       CALL            R0059 (G55,(SP)+) -> -(SP)
       RET_POPPED      

Routine R0059, 5 locals (0000, 0000, 0000, 0000, 0000)

       LOADW           L00,G51 -> L02
       JZ              L02 [TRUE] RTRUE
       TEST            L01,#02 [TRUE] L0001
       TEST            L01,#08 [FALSE] RTRUE
L0001: DEC_CHK         L02,#00 [TRUE] RTRUE
       ADD             L02,#01 -> -(SP)
       LOADW           L00,(SP)+ -> L03
       JE              L03,#0c [FALSE] L0002
       STORE           L03,G6b
L0002: CALL            R0252 (L03) -> -(SP)
       JZ              (SP)+ [FALSE] L0001
       JE              L03,#01 [TRUE] L0001
       STORE           G76,L03
       TEST_ATTR       L03,#0d [FALSE] L0003
       STORE           L04,#01
       JUMP            L0006
L0003: JE              G6f,#04 [TRUE] L0004
       STORE           L04,#00
       JUMP            L0006
L0004: TEST            L01,#08 [FALSE] L0005
       CALL            R0238 (#00) -> -(SP)
       JE              (SP)+,#01 [FALSE] L0005
       STORE           L04,#00
       JUMP            L0006
L0005: STORE           L04,#01
L0006: JZ              L04 [TRUE] L0008
       TEST            L01,#02 [FALSE] L0008
       JE              L03,#0b [FALSE] L0007
       PRINT           "You don't have that!"
       NEW_LINE        
       RFALSE          
L0007: PRINT           "You don't have the "
       PRINT_OBJ       L03
       PRINT           "."
       NEW_LINE        
       RFALSE          
L0008: JZ              L04 [FALSE] L0001
       JE              G6f,#04 [FALSE] L0001
       PRINT           "(Taken)"
       NEW_LINE        
       JUMP            L0001

Routine R0060, 3 locals (0000, 0000, 0000)

       LOADW           G56,G51 -> -(SP)
       JG              (SP)+,#01 [FALSE] L0001
       LOADB           G73,#05 -> -(SP)
       TEST            (SP)+,#04 [TRUE] L0001
       STORE           L00,#01
       JUMP            L0002
L0001: LOADW           G55,G51 -> -(SP)
       JG              (SP)+,#01 [FALSE] L0002
       LOADB           G73,#06 -> -(SP)
       TEST            (SP)+,#04 [TRUE] L0002
       STORE           L00,#02
L0002: JZ              L00 [TRUE] RTRUE
       PRINT           "You can't use multiple "
       JE              L00,#02 [FALSE] L0003
       PRINT           "in"
L0003: PRINT           "direct objects with ""
       LOADW           G64,#01 -> L01
       JZ              L01 [FALSE] L0004
       PRINT           "tell"
       JUMP            L0007
L0004: JZ              G69 [FALSE] L0005
       JZ              G68 [TRUE] L0006
L0005: LOADW           L01,#00 -> -(SP)
       PRINT_ADDR      (SP)+
       JUMP            L0007
L0006: LOADB           L01,#02 -> L02
       LOADB           L01,#03 -> -(SP)
       CALL            R0033 (L02,(SP)+) -> -(SP)
L0007: PRINT           ""."
       NEW_LINE        
       RFALSE          

Routine R0061, 4 locals (0000, 0000, ffff, 0001)

       JZ              L01 [TRUE] RFALSE
       JL              L02,#00 [TRUE] L0001
       STORE           L03,#00
       JUMP            L0002
L0001: LOADW           L01,#00 -> L02
L0002: LOADW           L01,L03 -> -(SP)
       JE              L00,(SP)+ [TRUE] RTRUE
       INC_CHK         L03,L02 [FALSE] L0002
       RFALSE          

Routine R0062, 4 locals (0000, 0000, 0000, 0000)

L0001: LOADB           L01,L03 -> -(SP)
       JE              L00,(SP)+ [TRUE] RTRUE
       INC_CHK         L03,L02 [FALSE] L0001
       RFALSE          

Routine R0063, 4 locals (0000, 0001, 0000, 0000)

       JZ              G48 [TRUE] L0001
       JE              G6f,G80 [TRUE] RTRUE
L0001: STORE           G5b,#14
       STORE           L02,G00
       STORE           G00,L00
       JZ              L01 [TRUE] L0002
       TEST_ATTR       L00,#14 [FALSE] L0002
       STORE           L03,#01
       JUMP            L0004
L0002: STOREW          G53,G51,#00
       STORE           G75,G53
       STORE           G5c,#ffff
       JE              L02,L00 [FALSE] L0003
       CALL            R0055 (G6f,#01,#01) -> -(SP)
       JE              G6f,G80 [TRUE] L0003
       JIN             G80,L00 [FALSE] L0003
       CALL            R0055 (G80,#01,#01) -> -(SP)
L0003: CALL            R0055 (L00,#01,#01) -> -(SP)
       LOADW           G75,G51 -> -(SP)
       JG              (SP)+,#00 [FALSE] L0004
       STORE           L03,#01
L0004: STORE           G00,L02
       STORE           G5b,#00
       RET             L03

Routine R0064, 1 local (0000)

       JZ              G68 [FALSE] L0001
       LOADW           G64,#06 -> L00
       LOADW           L00,#00 -> -(SP)
       JE              (SP)+,"it" [FALSE] L0002
L0001: PRINT           " "
       PRINT_OBJ       G76
       RTRUE           
L0002: LOADW           G64,#07 -> -(SP)
       CALL            R0040 (L00,(SP)+,#00) -> -(SP)
       RET_POPPED      

Routine R0065, 1 local (0000)

       JZ              G68 [FALSE] L0001
       LOADW           G64,#08 -> L00
       LOADW           L00,#00 -> -(SP)
       JE              (SP)+,"it" [FALSE] L0002
L0001: PRINT           " "
       PRINT_OBJ       G76
       RTRUE           
L0002: LOADW           G64,#09 -> -(SP)
       CALL            R0040 (L00,(SP)+,#00) -> -(SP)
       RET_POPPED      

Routine R0066, 4 locals (0000, 0000, 0000, 0000)

       TEST_ATTR       L00,#07 [TRUE] RFALSE
       JZ              G5a [TRUE] L0001
       GET_PROP_ADDR   L00,#12 -> L02
       GET_PROP_LEN    L02 -> -(SP)
       DIV             (SP)+,#02 -> -(SP)
       SUB             (SP)+,#01 -> -(SP)
       CALL            R0061 (G5a,L02,(SP)+) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
L0001: JZ              G59 [TRUE] L0002
       GET_PROP_ADDR   L00,#10 -> L02
       JZ              L02 [TRUE] RFALSE
       GET_PROP_LEN    L02 -> -(SP)
       SUB             (SP)+,#01 -> -(SP)
       CALL            R0062 (G59,L02,(SP)+) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
L0002: JZ              G5b [TRUE] RTRUE
       TEST_ATTR       L00,G5b [TRUE] RTRUE
       RFALSE          

Routine R0067, 0 locals ()
    Action routine for:
        "verbos"

       STORE           G47,#01
       STORE           G46,#00
       PRINT_RET       "Maximum verbosity."

Routine R0068, 0 locals ()
    Action routine for:
        "brief"

       STORE           G47,#00
       STORE           G46,#00
       PRINT_RET       "Brief descriptions."

Routine R0069, 0 locals ()
    Action routine for:
        "super"

       STORE           G46,#01
       PRINT_RET       "Super-brief descriptions."

Routine R0070, 0 locals ()
    Action routine for:
        "i"

       GET_CHILD       G6f -> -(SP) [FALSE] L0001
       CALL            R0231 (G6f) -> -(SP)
       RET_POPPED      
L0001: PRINT_RET       "You are empty-handed."

Routine R0071, 2 locals (0001, 0000)
    Action routine for:
        "q"

       CALL            R0430 -> -(SP)
       JZ              L00 [TRUE] L0001
       PRINT           "Do you wish to leave the game? (Y is affirmative): "
       CALL            R0237 -> -(SP)
       JZ              (SP)+ [FALSE] L0002
L0001: JZ              L00 [FALSE] L0003
L0002: QUIT            
       RTRUE           
L0003: PRINT_RET       "Ok."

Routine R0072, 0 locals ()
    Action routine for:
        "restar"

       CALL            R0430 (#01) -> -(SP)
       PRINT           "Do you wish to restart? (Y is affirmative): "
       CALL            R0237 -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       PRINT           "Restarting."
       NEW_LINE        
       RESTART         
       PRINT_RET       "Failed."

Routine R0073, 0 locals ()
    Action routine for:
        "restor"

       RESTORE         [FALSE] L0001
       PRINT           "Ok."
       NEW_LINE        
       CALL            R0226 -> -(SP)
       RET_POPPED      
L0001: PRINT_RET       "Failed."

Routine R0074, 0 locals ()
    Action routine for:
        "save"

       SAVE            [FALSE] L0001
       PRINT_RET       "Ok."
L0001: PRINT_RET       "Failed."

Routine R0075, 0 locals ()
    Action routine for:
        "script"

       LOADW           #00,#08 -> -(SP)
       OR              (SP)+,#01 -> -(SP)
       STOREW          #00,#08,(SP)+
       PRINT           "Here begins a transcript of interaction with"
       NEW_LINE        
       CALL            R0077 -> -(SP)
       RTRUE           

Routine R0076, 0 locals ()
    Action routine for:
        "unscri"

       PRINT           "Here ends a transcript of interaction with"
       NEW_LINE        
       CALL            R0077 -> -(SP)
       LOADW           #00,#08 -> -(SP)
       AND             (SP)+,#fffe -> -(SP)
       STOREW          #00,#08,(SP)+
       RTRUE           

Routine R0077, 1 local (0011)
    Action routine for:
        "versio"

       PRINT           "ZORK I: The Great Underground Empire
Copyright (c) 1981, 1982, 1983 Infocom, Inc. "
       PRINT           "All rights reserved."
       NEW_LINE        
       LOADB           #00,#01 -> -(SP)
       AND             (SP)+,#08 -> -(SP)
       JZ              (SP)+ [TRUE] L0001
       PRINT           "Licensed to Tandy Corporation."
       NEW_LINE        
L0001: PRINT           "ZORK is a registered trademark of Infocom, Inc.
Revision "
       LOADW           #00,#01 -> -(SP)
       AND             (SP)+,#07ff -> -(SP)
       PRINT_NUM       (SP)+
       PRINT           " / Serial number "
L0002: INC_CHK         L00,#17 [FALSE] L0003
       JUMP            L0004
L0003: LOADB           #00,L00 -> -(SP)
       PRINT_CHAR      (SP)+
       JUMP            L0002
L0004: NEW_LINE        
       RTRUE           

Routine R0078, 0 locals ()
    Action routine for:
        "$ve"

       PRINT           "Verifying disk..."
       NEW_LINE        
       VERIFY          [FALSE] L0001
       PRINT_RET       "The disk is correct."
L0001: NEW_LINE        
       PRINT_RET       "** Disk Failure **"

Routine R0079, 0 locals ()
    Action routine for:
        "plugh"

       PRINT_RET       "A hollow voice says "Fool.""

Routine R0080, 1 local (0000)
    Action routine for:
        "again"

       JE              G7e,#89 [FALSE] L0001
       CALL            R0026 (G7e,G7d) -> -(SP)
       RET_POPPED      
L0001: JZ              G7d [TRUE] L0003
       GET_PARENT      G7d -> -(SP)
       JZ              (SP)+ [TRUE] L0002
       TEST_ATTR       G7d,#07 [FALSE] L0003
L0002: STORE           L00,G7d
L0003: JZ              G7c [TRUE] L0005
       GET_PARENT      G7c -> -(SP)
       JZ              (SP)+ [TRUE] L0004
       TEST_ATTR       G7c,#07 [FALSE] L0005
L0004: STORE           L00,G7c
L0005: JZ              L00 [TRUE] L0006
       JE              L00,#0d,#52 [TRUE] L0006
       PRINT           "You can't see the "
       PRINT_OBJ       L00
       PRINT           " anymore."
       NEW_LINE        
       RET             #02
L0006: CALL            R0026 (G7e,G7d,G7c) -> -(SP)
       RET_POPPED      

Routine R0081, 0 locals ()
    Action routine for:
        "awake up OBJ"
        "awake OBJ"

       TEST_ATTR       G76,#1e [FALSE] L0002
       GET_PROP        G76,#07 -> -(SP)
       JL              (SP)+,#00 [FALSE] L0001
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " is rudely awakened."
       NEW_LINE        
       CALL            R0421 (G76) -> -(SP)
       RET_POPPED      
L0001: PRINT_RET       "He's wide awake, or haven't you noticed..."
L0002: PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " isn't sleeping."

Routine R0082, 0 locals ()
    Action routine for:
        "answer"

       PRINT           "Nobody seems to be awaiting your answer."
       NEW_LINE        
       STORE           G6c,#00
       STORE           G60,#00
       RTRUE           

Routine R0083, 0 locals ()
    Action routine for:
        "strike OBJ with OBJ"
        "knock down OBJ"
        "stab OBJ with OBJ"
        "dispat OBJ with OBJ"
        "attack OBJ with OBJ"

       TEST_ATTR       G76,#1e [TRUE] L0001
       PRINT           "I've known strange people, but fighting a "
       PRINT_OBJ       G76
       PRINT_RET       "?"
L0001: JZ              G77 [TRUE] L0002
       JE              G77,#01 [FALSE] L0003
L0002: PRINT           "Trying to attack a "
       PRINT_OBJ       G76
       PRINT_RET       " with your bare hands is suicidal."
L0003: JIN             G77,G6f [TRUE] L0004
       PRINT           "You aren't even holding the "
       PRINT_OBJ       G77
       PRINT_RET       "."
L0004: TEST_ATTR       G77,#1d [TRUE] L0005
       PRINT           "Trying to attack the "
       PRINT_OBJ       G76
       PRINT           " with a "
       PRINT_OBJ       G77
       PRINT_RET       " is suicidal."
L0005: CALL            R0415 -> -(SP)
       RET_POPPED      

Routine R0084, 0 locals ()
    Action routine for:
        "back"

       PRINT_RET       "Sorry, my memory is poor. Please give a direction."

Routine R0085, 0 locals ()
    Action routine for:
        "blow up OBJ"
        "blast"

       PRINT_RET       "You can't blast anything by using words."

Routine R0086, 1 local (0000)
    Pre-action routine for:
        "carry in OBJ"
        "climb in OBJ"
        "board OBJ"

       GET_PARENT      G6f -> L00
       CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RTRUE
       TEST_ATTR       G76,#1b [FALSE] L0002
       JIN             G76,G00 [TRUE] L0001
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " must be on the ground to be boarded."
       NEW_LINE        
       RET             #02
L0001: TEST_ATTR       L00,#1b [FALSE] RFALSE
       PRINT           "You are already in the "
       PRINT_OBJ       L00
       PRINT           "!"
       NEW_LINE        
       RET             #02
L0002: PRINT           "You have a theory on how to board a "
       PRINT_OBJ       G76
       PRINT           ", perhaps?"
       NEW_LINE        
       RET             #02

Routine R0087, 1 local (0000)
    Action routine for:
        "carry in OBJ"
        "climb in OBJ"
        "board OBJ"

       PRINT           "You are now in the "
       PRINT_OBJ       G76
       PRINT           "."
       NEW_LINE        
       INSERT_OBJ      G6f,G76
       GET_PROP        G76,#11 -> -(SP)
       CALL            (SP)+ (#02) -> -(SP)
       RTRUE           

Routine R0088, 0 locals ()
    Action routine for:
        "blow in OBJ"

       CALL            R0026 (#17,G76,#06) -> -(SP)
       RET_POPPED      

Routine R0089, 0 locals ()
    Action routine for:
        "brush OBJ with OBJ"
        "brush OBJ"

       PRINT_RET       "If you wish, but heaven only knows why."

Routine R0090, 0 locals ()
    Action routine for:
        "bug"

       PRINT_RET       "Bug? Not in a flawless program like this! (Cough,
cough)."

Routine R0091, 0 locals ()
    Pre-action routine for:
        "light OBJ with OBJ"
        "burn down OBJ with OBJ"
        "burn OBJ with OBJ"

       TEST_ATTR       G77,#19 [FALSE] L0001
       TEST_ATTR       G77,#14 [TRUE] RFALSE
L0001: PRINT           "With a "
       PRINT_OBJ       G77
       PRINT_RET       "??!?"

Routine R0092, 0 locals ()
    Action routine for:
        "light OBJ with OBJ"
        "burn down OBJ with OBJ"
        "burn OBJ with OBJ"

       CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RFALSE
       TEST_ATTR       G76,#1a [FALSE] L0005
       JIN             G76,G6f [TRUE] L0001
       JIN             G6f,G76 [FALSE] L0004
L0001: CALL            R0116 (G76) -> -(SP)
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " catches fire. Unfortunately, you were "
       JIN             G6f,G76 [FALSE] L0002
       PRINT           "in"
       JUMP            L0003
L0002: PRINT           "holding"
L0003: CALL            R0431 (S165) -> -(SP)
       RET_POPPED      
L0004: CALL            R0116 (G76) -> -(SP)
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " catches fire and is consumed."
L0005: PRINT           "You can't burn a "
       PRINT_OBJ       G76
       PRINT_RET       "."

Routine R0093, 0 locals ()
    Action routine for:
        "barf"

       PRINT_RET       "Preposterous!"

Routine R0094, 0 locals ()
    Action routine for:
        "go down OBJ"
        "climb down OBJ"
        "climb"

       CALL            R0097 (#16,G76) -> -(SP)
       RET_POPPED      

Routine R0095, 0 locals ()
    Action routine for:
        "climb OBJ"

       CALL            R0097 (#17,G76) -> -(SP)
       RET_POPPED      

Routine R0096, 0 locals ()
    Action routine for:
        "carry on OBJ"
        "climb on OBJ"

       TEST_ATTR       G76,#1b [FALSE] L0001
       CALL            R0026 (#19,G76) -> -(SP)
       RTRUE           
L0001: PRINT           "You can't climb onto the "
       PRINT_OBJ       G76
       PRINT_RET       "."

Routine R0097, 5 locals (0017, 0000, 0000, 0000, 0000)
    Action routine for:
        "go up OBJ"
        "climb up OBJ"
        "climb"

       JZ              L01 [FALSE] L0001
       JZ              G76 [TRUE] L0001
       STORE           L01,G76
L0001: GET_PROP_ADDR   G00,L00 -> L03
       JZ              L03 [TRUE] L0007
       JZ              L01 [TRUE] L0006
       GET_PROP_LEN    L03 -> L02
       JE              L02,#02 [TRUE] L0002
       JE              L02,#04,#05,#01 [FALSE] L0006
       LOADB           L03,#00 -> -(SP)
       CALL            R0249 (G76,(SP)+) -> -(SP)
       JZ              (SP)+ [FALSE] L0006
L0002: PRINT           "The "
       PRINT_OBJ       L01
       PRINT           " do"
       JE              L01,#49 [TRUE] L0003
       PRINT           "es"
L0003: PRINT           "n't lead "
       JE              L00,#17 [FALSE] L0004
       PRINT           "up"
       JUMP            L0005
L0004: PRINT           "down"
L0005: PRINT_RET       "ward."
L0006: CALL            R0247 (L00) -> -(SP)
       RTRUE           
L0007: JZ              L01 [FALSE] L0008
       PRINT_RET       "You can't go that way."
L0008: JZ              L01 [TRUE] L0009
       GET_PROP_ADDR   G76,#12 -> L02
       GET_PROP_LEN    L02 -> -(SP)
       CALL            R0061 ("wall",L02,(SP)+) -> -(SP)
       JZ              (SP)+ [TRUE] L0009
       PRINT_RET       "Climbing the walls is to no avail."
L0009: PRINT_RET       "You can't do that!"

Routine R0098, 0 locals ()
    Action routine for:
        "close OBJ"

       TEST_ATTR       G76,#13 [TRUE] L0001
       TEST_ATTR       G76,#17 [TRUE] L0001
       PRINT           "You must tell me how to do that to a "
       PRINT_OBJ       G76
       PRINT_RET       "."
L0001: TEST_ATTR       G76,#0a [TRUE] L0003
       GET_PROP        G76,#0a -> -(SP)
       JZ              (SP)+ [TRUE] L0003
       TEST_ATTR       G76,#0b [FALSE] L0002
       CLEAR_ATTR      G76,#0b
       PRINT           "Closed."
       NEW_LINE        
       JZ              G42 [TRUE] RTRUE
       CALL            R0063 (G00) -> G42
       JZ              G42 [FALSE] RTRUE
       PRINT_RET       "It is now pitch black."
L0002: PRINT_RET       "It is already closed."
L0003: TEST_ATTR       G76,#17 [FALSE] L0005
       TEST_ATTR       G76,#0b [FALSE] L0004
       CLEAR_ATTR      G76,#0b
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " is now closed."
L0004: PRINT_RET       "It is already closed."
L0005: PRINT_RET       "You cannot close that."

Routine R0099, 0 locals ()
    Action routine for:
        "comman OBJ"

       TEST_ATTR       G76,#1e [FALSE] L0001
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " pays no attention."
L0001: PRINT_RET       "You cannot talk to that!"

Routine R0100, 0 locals ()
    Action routine for:
        "count OBJ"

       JE              G76,#0a [FALSE] L0001
       PRINT_RET       "Well, for one, you are playing Zork..."
L0001: PRINT_RET       "You have lost your mind."

Routine R0101, 0 locals ()
    Action routine for:
        "cross OBJ"

       PRINT_RET       "You can't cross that!"

Routine R0102, 0 locals ()
    Action routine for:
        "curse OBJ"
        "curse"

       JZ              G76 [TRUE] L0002
       TEST_ATTR       G76,#1e [FALSE] L0001
       PRINT_RET       "Insults of this nature won't help you."
L0001: PRINT_RET       "What a loony!"
L0002: PRINT_RET       "Such language in a high-class establishment like this!"

Routine R0103, 0 locals ()
    Action routine for:
        "cut OBJ with OBJ"

       TEST_ATTR       G76,#1e [FALSE] L0001
       CALL            R0026 (#13,G76,G77) -> -(SP)
       RET_POPPED      
L0001: TEST_ATTR       G76,#1a [FALSE] L0003
       TEST_ATTR       G77,#1d [FALSE] L0003
       JIN             G6f,G76 [FALSE] L0002
       PRINT_RET       "Not a bright idea, especially since you're in it."
L0002: CALL            R0116 (G76) -> -(SP)
       PRINT           "Your skillful "
       PRINT_OBJ       G77
       PRINT           "smanship slices the "
       PRINT_OBJ       G76
       PRINT_RET       " into innumerable slivers which blow away."
L0003: TEST_ATTR       G77,#1d [TRUE] L0004
       PRINT           "The "cutting edge" of a "
       PRINT_OBJ       G77
       PRINT_RET       " is hardly adequate."
L0004: PRINT           "Strange concept, cutting the "
       PRINT_OBJ       G76
       PRINT_RET       "...."

Routine R0104, 0 locals ()
    Action routine for:
        "deflat OBJ"

       PRINT_RET       "Come on, now!"

Routine R0105, 0 locals ()
    Action routine for:
        "dig OBJ with OBJ"
        "dig in OBJ with OBJ"

       JZ              G77 [FALSE] L0001
       STORE           G77,#01
L0001: JE              G77,#79 [FALSE] L0002
       PRINT_RET       "There's no reason to be digging here."
L0002: TEST_ATTR       G77,#1c [FALSE] L0003
       PRINT           "Digging with the "
       PRINT_OBJ       G77
       PRINT_RET       " is slow and tedious."
L0003: PRINT           "Digging with a "
       PRINT_OBJ       G77
       PRINT_RET       " is silly."

Routine R0106, 0 locals ()
    Action routine for:
        "carry out OBJ"
        "disemb OBJ"

       GET_PARENT      G6f -> -(SP)
       JE              (SP)+,G76 [TRUE] L0001
       PRINT           "You're not in that!"
       NEW_LINE        
       RET             #02
L0001: TEST_ATTR       G00,#06 [FALSE] L0002
       PRINT           "You are on your own feet again."
       NEW_LINE        
       INSERT_OBJ      G6f,G00
       RTRUE           
L0002: PRINT           "You realize that getting out here would be fatal."
       NEW_LINE        
       RET             #02

Routine R0107, 0 locals ()
    Action routine for:
        "disenc OBJ"

       PRINT_RET       "Nothing happens."

Routine R0108, 0 locals ()
    Action routine for:
        "drink OBJ"

       CALL            R0112 -> -(SP)
       RET_POPPED      

Routine R0109, 0 locals ()
    Action routine for:
        "drink from OBJ"

       PRINT_RET       "How peculiar!"

Routine R0110, 0 locals ()
    Pre-action routine for:
        "hide down OBJ"
        "pour OBJ from OBJ"
        "pour OBJ in OBJ"
        "pour OBJ"
        "leave OBJ"
        "drop OBJ"

       GET_PARENT      G6f -> -(SP)
       JE              G76,(SP)+ [FALSE] RFALSE
       CALL            R0026 (#2d,G76) -> -(SP)
       RTRUE           

Routine R0111, 0 locals ()
    Action routine for:
        "hide down OBJ"
        "pour OBJ from OBJ"
        "pour OBJ in OBJ"
        "pour OBJ"
        "leave OBJ"
        "drop OBJ"

       CALL            R0239 -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       PRINT_RET       "Dropped."

Routine R0112, 3 locals (0000, 0000, 0000)
    Action routine for:
        "bite OBJ"

       TEST_ATTR       G76,#15 [TRUE] L0001
       PUSH            #00
       JUMP            L0002
L0001: PUSH            #01
L0002: STORE           L00,(SP)+
       JZ              L00 [TRUE] L0006
       JIN             G76,G6f [TRUE] L0003
       GET_PARENT      G76 -> -(SP)
       JIN             (SP)+,G6f [TRUE] L0003
       PRINT           "You're not holding that."
       NEW_LINE        
       JUMP            L0005
L0003: JE              G78,#2f [FALSE] L0004
       PRINT           "How can you drink that?"
       JUMP            L0005
L0004: PRINT           "Thank you very much. It really hit the spot."
       CALL            R0116 (G76) -> -(SP)
L0005: NEW_LINE        
       RTRUE           
L0006: TEST_ATTR       G76,#16 [FALSE] L0012
       STORE           L01,#01
       GET_PARENT      G76 -> L02
       JIN             G76,#f7 [TRUE] L0007
       JIN             G76,#f9 [TRUE] L0007
       JE              G76,#0d [FALSE] L0008
L0007: CALL            R0113 -> -(SP)
       RET_POPPED      
L0008: JZ              L02 [FALSE] L0009
       PRINT_RET       "You don't have any to drink."
L0009: JIN             L02,G6f [TRUE] L0010
       PRINT           "You have to be holding the "
       PRINT_OBJ       L02
       PRINT_RET       " first."
L0010: TEST_ATTR       L02,#0b [TRUE] L0011
       PRINT           "You'll have to open the "
       PRINT_OBJ       L02
       PRINT_RET       " first."
L0011: CALL            R0113 -> -(SP)
       RET_POPPED      
L0012: JZ              L00 [FALSE] RFALSE
       JZ              L01 [FALSE] RFALSE
       PRINT           "I don't think that the "
       PRINT_OBJ       G76
       PRINT_RET       " would agree with you."

Routine R0113, 0 locals ()

       PRINT           "Thank you very much. I was rather thirsty (from all
this talking, probably)."
       NEW_LINE        
       CALL            R0116 (G76) -> -(SP)
       RET_POPPED      

Routine R0114, 5 locals (0000, 0000, 0000, 0000, 0000)
    Action routine for:
        "echo"

       LOADB           G6e,#01 -> -(SP)
       JG              (SP)+,#00 [FALSE] L0006
       LOADB           G6e,#01 -> -(SP)
       MUL             (SP)+,#04 -> -(SP)
       ADD             G6e,(SP)+ -> L00
       LOADB           L00,#00 -> L04
       LOADB           L00,#01 -> -(SP)
       ADD             L04,(SP)+ -> -(SP)
       SUB             (SP)+,#01 -> L01
L0001: INC_CHK         L02,#02 [FALSE] L0002
       PRINT_RET       "..."
L0002: LOADB           L00,#01 -> -(SP)
       SUB             (SP)+,#01 -> L03
L0003: INC_CHK         L03,L01 [FALSE] L0004
       JUMP            L0005
L0004: LOADB           G6d,L03 -> -(SP)
       PRINT_CHAR      (SP)+
       JUMP            L0003
L0005: PRINT           " "
       JUMP            L0001
L0006: PRINT_RET       "echo echo ..."

Routine R0115, 0 locals ()
    Action routine for:
        "enchan OBJ"

       CALL            R0013 -> -(SP)
       CALL            R0107 -> -(SP)
       RET_POPPED      

Routine R0116, 2 locals (0000, 0000)

       JE              L00,G6b [FALSE] L0001
       STORE           G6b,#00
       STORE           G6a,#00
L0001: STORE           L01,G42
       REMOVE_OBJ      L00
       CALL            R0063 (G00) -> G42
       JZ              L01 [TRUE] RTRUE
       JE              L01,G42 [TRUE] RTRUE
       PRINT_RET       "You are left in the dark..."

Routine R0117, 0 locals ()
    Action routine for:
        "enter"

       CALL            R0247 (#15) -> -(SP)
       RET_POPPED      

Routine R0118, 0 locals ()
    Action routine for:
        "gaze at OBJ"
        "descri OBJ"

       GET_PROP        G76,#08 -> -(SP)
       JZ              (SP)+ [TRUE] L0001
       GET_PROP        G76,#08 -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           
L0001: TEST_ATTR       G76,#13 [TRUE] L0002
       TEST_ATTR       G76,#17 [FALSE] L0003
L0002: CALL            R0146 -> -(SP)
       RET_POPPED      
L0003: PRINT           "There's nothing special about the "
       PRINT_OBJ       G76
       PRINT_RET       "."

Routine R0119, 0 locals ()
    Action routine for:
        "exit OBJ"
        "exit"

       CALL            R0247 (#14) -> -(SP)
       RET_POPPED      

Routine R0120, 0 locals ()
    Action routine for:
        "banish away OBJ"
        "banish out OBJ"
        "banish OBJ"

       PRINT_RET       "What a bizarre concept!"

Routine R0121, 1 local (0000)
    Pre-action routine for:
        "fill OBJ"
        "fill OBJ with OBJ"

       JZ              G77 [FALSE] L0002
       GET_PROP_ADDR   G00,#05 -> L00
       JZ              L00 [TRUE] L0002
       GET_PROP_LEN    L00 -> -(SP)
       SUB             (SP)+,#01 -> -(SP)
       CALL            R0062 (#ee,L00,(SP)+) -> -(SP)
       JZ              (SP)+ [TRUE] L0001
       STORE           G77,#ee
       RFALSE          
L0001: PRINT_RET       "There is nothing to fill it with."
L0002: JE              G77,#ee [TRUE] RFALSE
       CALL            R0026 (#12,G77,G76) -> -(SP)
       RTRUE           

Routine R0122, 0 locals ()
    Action routine for:
        "fill OBJ"
        "fill OBJ with OBJ"

       JZ              G77 [FALSE] L0003
       CALL            R0249 (#ee,G00) -> -(SP)
       JZ              (SP)+ [TRUE] L0001
       CALL            R0026 (#3b,G76,#ee) -> -(SP)
       RTRUE           
L0001: GET_PARENT      G6f -> -(SP)
       JIN             "quantity of water",(SP)+ [FALSE] L0002
       CALL            R0026 (#3b,G76,#ed) -> -(SP)
       RTRUE           
L0002: PRINT_RET       "There's nothing to fill it with."
L0003: PRINT_RET       "You may know how to do that, but I don't."

Routine R0123, 1 local (0000)
    Action routine for:
        "search for OBJ"
        "gaze for OBJ"
        "find OBJ"

       GET_PARENT      G76 -> L00
       JE              G76,#01,#06 [FALSE] L0001
       PRINT_RET       "Within six feet of your head, assuming you haven't left
that somewhere."
L0001: JE              G76,#05 [FALSE] L0002
       PRINT_RET       "You're around here somewhere..."
L0002: JE              L00,#f7 [FALSE] L0003
       PRINT_RET       "You find it."
L0003: JIN             G76,G6f [FALSE] L0004
       PRINT_RET       "You have it."
L0004: JIN             G76,G00 [TRUE] L0005
       CALL            R0249 (G76,G00) -> -(SP)
       JZ              (SP)+ [FALSE] L0005
       JE              G76,#0d [FALSE] L0006
L0005: PRINT_RET       "It's right here."
L0006: TEST_ATTR       L00,#1e [FALSE] L0007
       PRINT           "The "
       PRINT_OBJ       L00
       PRINT_RET       " has it."
L0007: TEST_ATTR       L00,#0a [FALSE] L0008
       PRINT           "It's on the "
       PRINT_OBJ       L00
       PRINT_RET       "."
L0008: TEST_ATTR       L00,#13 [FALSE] L0009
       PRINT           "It's in the "
       PRINT_OBJ       L00
       PRINT_RET       "."
L0009: PRINT_RET       "Beats me."

Routine R0124, 0 locals ()
    Action routine for:
        "chase OBJ"
        "chase"

       PRINT_RET       "You're nuts!"

Routine R0125, 0 locals ()
    Action routine for:
        "froboz"

       PRINT_RET       "The FROBOZZ Corporation created, owns, and operates
this dungeon."

Routine R0126, 0 locals ()
    Pre-action routine for:
        "hand OBJ to OBJ"
        "donate OBJ to OBJ"

       CALL            R0252 (G76) -> -(SP)
       JZ              (SP)+ [FALSE] RFALSE
       PRINT           "That's easy for you to say since you don't even have
the "
       PRINT_OBJ       G76
       PRINT_RET       "."

Routine R0127, 0 locals ()
    Action routine for:
        "hand OBJ to OBJ"
        "donate OBJ to OBJ"

       TEST_ATTR       G77,#1e [TRUE] L0001
       PRINT           "You can't give a "
       PRINT_OBJ       G76
       PRINT           " to a "
       PRINT_OBJ       G77
       PRINT_RET       "!"
L0001: PRINT           "The "
       PRINT_OBJ       G77
       PRINT_RET       " refuses it politely."

Routine R0128, 0 locals ()
    Action routine for:
        "hatch OBJ"

       PRINT_RET       "Bizarre!"

Routine R0129, 0 locals ()
    Action routine for:
        "hello OBJ"
        "hello"

       JZ              G76 [TRUE] L0002
       TEST_ATTR       G76,#1e [FALSE] L0001
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " bows his head to you in greeting."
L0001: PRINT           "It's a well known fact that only schizophrenics say
"Hello" to a "
       PRINT_OBJ       G76
       PRINT_RET       "."
L0002: CALL            R0004 (G36) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           

Routine R0130, 0 locals ()
    Action routine for:
        "chant"

       PRINT           "The incantation echoes back faintly, but nothing else
happens."
       NEW_LINE        
       STORE           G60,#00
       STORE           G6c,#00
       RTRUE           

Routine R0131, 0 locals ()
    Action routine for:
        "inflat OBJ with OBJ"
        "blow up OBJ with OBJ"

       PRINT_RET       "How can you inflate that?"

Routine R0132, 0 locals ()
    Action routine for:
        "is OBJ on OBJ"
        "is OBJ in OBJ"

       JIN             G76,G77 [FALSE] L0003
       PRINT           "Yes, it is "
       TEST_ATTR       G77,#0a [FALSE] L0001
       PRINT           "on"
       JUMP            L0002
L0001: PRINT           "in"
L0002: PRINT           " the "
       PRINT_OBJ       G77
       PRINT_RET       "."
L0003: PRINT_RET       "No, it isn't."

Routine R0133, 0 locals ()
    Action routine for:
        "kick OBJ"

       CALL            R0242 (S166) -> -(SP)
       RET_POPPED      

Routine R0134, 0 locals ()
    Action routine for:
        "kiss OBJ"

       PRINT_RET       "I'd sooner kiss a pig."

Routine R0135, 0 locals ()
    Action routine for:
        "knock on OBJ"
        "knock at OBJ"

       TEST_ATTR       G76,#17 [FALSE] L0001
       PRINT_RET       "Nobody's home."
L0001: PRINT           "Why knock on a "
       PRINT_OBJ       G76
       PRINT_RET       "?"

Routine R0136, 0 locals ()
    Action routine for:
        "flip off OBJ"
        "hide out OBJ"
        "douse OBJ"
        "blow out OBJ"

       TEST_ATTR       G76,#1f [FALSE] L0003
       TEST_ATTR       G76,#14 [TRUE] L0001
       PRINT_RET       "It is already off."
L0001: CLEAR_ATTR      G76,#14
       JZ              G42 [TRUE] L0002
       CALL            R0063 (G00) -> G42
L0002: PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " is now off."
       NEW_LINE        
       JZ              G42 [FALSE] RTRUE
       PRINT           "It is now pitch black."
       NEW_LINE        
       RTRUE           
L0003: PRINT_RET       "You can't turn that off."

Routine R0137, 0 locals ()
    Action routine for:
        "flip on OBJ with OBJ"
        "flip on OBJ"
        "light OBJ"
        "activa OBJ"

       TEST_ATTR       G76,#1f [FALSE] L0002
       TEST_ATTR       G76,#14 [FALSE] L0001
       PRINT_RET       "It is already on."
L0001: SET_ATTR        G76,#14
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " is now on."
       NEW_LINE        
       JZ              G42 [FALSE] RTRUE
       CALL            R0063 (G00) -> G42
       NEW_LINE        
       CALL            R0144 -> -(SP)
       RTRUE           
L0002: PRINT_RET       "You can't turn that on."

Routine R0138, 0 locals ()
    Action routine for:
        "launch OBJ"

       TEST_ATTR       G76,#1b [FALSE] L0001
       PRINT_RET       "You can't launch that by saying "launch"!"
L0001: PRINT_RET       "That's pretty weird."

Routine R0139, 0 locals ()
    Action routine for:
        "lean on OBJ"

       PRINT_RET       "Getting tired?"

Routine R0140, 2 locals (0000, 0000)
    Action routine for:
        "go over OBJ"
        "dive off OBJ"
        "dive from OBJ"
        "dive in OBJ"
        "dive across OBJ"
        "dive over OBJ"
        "dive"

       JZ              G76 [TRUE] L0003
       JIN             G76,G00 [FALSE] L0002
       TEST_ATTR       G76,#1e [FALSE] L0001
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " is too big to jump over."
L0001: CALL            R0190 -> -(SP)
       RET_POPPED      
L0002: PRINT_RET       "That would be a good trick."
L0003: GET_PROP_ADDR   G00,#16 -> L00
       JZ              L00 [TRUE] L0007
       GET_PROP_LEN    L00 -> L01
       JE              L01,#02 [TRUE] L0004
       JE              L01,#04 [FALSE] L0005
       LOADB           L00,#01 -> -(SP)
       LOAD            [(SP)+] -> -(SP)
       JZ              (SP)+ [FALSE] L0005
L0004: PRINT           "This was not a very safe place to try jumping."
       NEW_LINE        
       CALL            R0004 (G44) -> -(SP)
       CALL            R0431 ((SP)+) -> -(SP)
       RET_POPPED      
L0005: JE              G00,#58 [FALSE] L0006
       PRINT           "In a feat of unaccustomed daring, you manage to land on
your feet without killing yourself."
       NEW_LINE        
       NEW_LINE        
       CALL            R0247 (#16) -> -(SP)
       RTRUE           
L0006: CALL            R0190 -> -(SP)
       RET_POPPED      
L0007: CALL            R0190 -> -(SP)
       RET_POPPED      

Routine R0141, 0 locals ()
    Action routine for:
        "leave"

       CALL            R0247 (#14) -> -(SP)
       RET_POPPED      

Routine R0142, 0 locals ()
    Action routine for:
        "listen for OBJ"
        "listen to OBJ"

       PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " makes no sound."

Routine R0143, 0 locals ()
    Action routine for:
        "lock OBJ with OBJ"

       PRINT_RET       "It doesn't seem to work."

Routine R0144, 0 locals ()
    Action routine for:
        "gaze down OBJ"
        "gaze up OBJ"
        "gaze around OBJ"
        "gaze"

       CALL            R0227 (#01) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       CALL            R0228 (#01) -> -(SP)
       RET_POPPED      

Routine R0145, 0 locals ()
    Action routine for:
        "gaze behind OBJ"

       PRINT           "There is nothing behind the "
       PRINT_OBJ       G76
       PRINT_RET       "."

Routine R0146, 0 locals ()
    Action routine for:
        "gaze in OBJ"
        "gaze with OBJ"
        "descri on OBJ"
        "descri in OBJ"

       TEST_ATTR       G76,#17 [FALSE] L0003
       TEST_ATTR       G76,#0b [FALSE] L0001
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " is open, but I can't tell what's beyond it."
       JUMP            L0002
L0001: PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " is closed."
L0002: NEW_LINE        
       RTRUE           
L0003: TEST_ATTR       G76,#13 [FALSE] L0007
       TEST_ATTR       G76,#1e [FALSE] L0004
       PRINT_RET       "There is nothing special to be seen."
L0004: CALL            R0233 (G76) -> -(SP)
       JZ              (SP)+ [TRUE] L0006
       GET_CHILD       G76 -> -(SP) [FALSE] L0005
       CALL            R0231 (G76) -> -(SP)
       JZ              (SP)+ [FALSE] RTRUE
L0005: PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " is empty."
L0006: PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " is closed."
L0007: PRINT           "You can't look inside a "
       PRINT_OBJ       G76
       PRINT_RET       "."

Routine R0147, 0 locals ()
    Action routine for:
        "gaze on OBJ"

       TEST_ATTR       G76,#0a [FALSE] L0001
       CALL            R0026 (#39,G76) -> -(SP)
       RTRUE           
L0001: PRINT           "Look on a "
       PRINT_OBJ       G76
       PRINT_RET       "???"

Routine R0148, 0 locals ()
    Action routine for:
        "gaze under OBJ"

       PRINT_RET       "There is nothing but dust there."

Routine R0149, 0 locals ()
    Action routine for:
        "lower OBJ"

       CALL            R0242 (S170) -> -(SP)
       RET_POPPED      

Routine R0150, 0 locals ()
    Action routine for:
        "make OBJ"

       PRINT_RET       "You can't do that."

Routine R0151, 0 locals ()
    Action routine for:
        "liquif OBJ with OBJ"

       PRINT           "It's not clear that a "
       PRINT_OBJ       G76
       PRINT_RET       " can be melted."

Routine R0152, 0 locals ()
    Pre-action routine for:
        "pull up OBJ"
        "pull on OBJ"
        "pull OBJ"
        "roll OBJ"
        "roll up OBJ"
        "move OBJ"

       CALL            R0252 (G76) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       PRINT_RET       "You aren't an accomplished enough juggler."

Routine R0153, 0 locals ()
    Action routine for:
        "pull up OBJ"
        "pull on OBJ"
        "pull OBJ"
        "roll OBJ"
        "roll up OBJ"
        "move OBJ"

       TEST_ATTR       G76,#11 [FALSE] L0001
       PRINT           "Moving the "
       PRINT_OBJ       G76
       PRINT_RET       " reveals nothing."
L0001: PRINT           "You can't move the "
       PRINT_OBJ       G76
       PRINT_RET       "."

Routine R0154, 0 locals ()
    Action routine for:
        "mumble"

       PRINT_RET       "You'll have to speak up if you expect me to hear you!"

Routine R0155, 0 locals ()
    Pre-action routine for:
        "punctu OBJ with OBJ"
        "poke OBJ with OBJ"
        "block down OBJ with OBJ"
        "block OBJ with OBJ"

       CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RTRUE
       JZ              G77 [TRUE] L0001
       TEST_ATTR       G77,#1d [TRUE] RFALSE
L0001: PRINT           "Trying to destroy the "
       PRINT_OBJ       G76
       PRINT           " with "
       JZ              G77 [FALSE] L0002
       PRINT           "your bare hands"
       JUMP            L0003
L0002: PRINT           "a "
       PRINT_OBJ       G77
L0003: PRINT_RET       " is futile."

Routine R0156, 0 locals ()
    Action routine for:
        "punctu OBJ with OBJ"
        "poke OBJ with OBJ"
        "block down OBJ with OBJ"
        "block OBJ with OBJ"

       TEST_ATTR       G76,#1e [FALSE] L0001
       CALL            R0026 (#13,G76) -> -(SP)
       RTRUE           
L0001: PRINT_RET       "Nice try."

Routine R0157, 0 locals ()
    Action routine for:
        "odysse"

       JE              G00,#b9 [FALSE] L0001
       JIN             "cyclops",G00 [FALSE] L0001
       JZ              G95 [FALSE] L0001
       CALL            R0023 (#649f) -> -(SP)
       STOREW          (SP)+,#00,#00
       STORE           G95,#01
       PRINT           "The cyclops, hearing the name of his father's deadly
nemesis, flees the room by knocking down the wall on the east of the room."
       NEW_LINE        
       STORE           G8f,#01
       CLEAR_ATTR      "cyclops",#02
       CALL            R0116 (#ba) -> -(SP)
       RET_POPPED      
L0001: PRINT_RET       "Wasn't he a sailor?"

Routine R0158, 0 locals ()
    Action routine for:
        "grease OBJ with OBJ"

       PRINT_RET       "You probably put spinach in your gas tank, too."

Routine R0159, 2 locals (0000, 0000)
    Action routine for:
        "open OBJ with OBJ"
        "open up OBJ"
        "open OBJ"
        "block in OBJ"

       TEST_ATTR       G76,#13 [FALSE] L0005
       GET_PROP        G76,#0a -> -(SP)
       JZ              (SP)+ [TRUE] L0005
       TEST_ATTR       G76,#0b [FALSE] L0001
       PRINT_RET       "It is already open."
L0001: SET_ATTR        G76,#0b
       SET_ATTR        G76,#03
       GET_CHILD       G76 -> -(SP) [FALSE] L0002
       TEST_ATTR       G76,#0c [FALSE] L0003
L0002: PRINT_RET       "Opened."
L0003: GET_CHILD       G76 -> L00 [FALSE] L0004
       GET_SIBLING     L00 -> -(SP) [TRUE] L0004
       TEST_ATTR       L00,#03 [TRUE] L0004
       GET_PROP        L00,#0e -> L01
       JZ              L01 [TRUE] L0004
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " opens."
       NEW_LINE        
       PRINT_PADDR     L01
       NEW_LINE        
       RTRUE           
L0004: PRINT           "Opening the "
       PRINT_OBJ       G76
       PRINT           " reveals "
       CALL            R0230 (G76) -> -(SP)
       PRINT_RET       "."
L0005: TEST_ATTR       G76,#17 [FALSE] L0007
       TEST_ATTR       G76,#0b [FALSE] L0006
       PRINT_RET       "It is already open."
L0006: PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " opens."
       NEW_LINE        
       SET_ATTR        G76,#0b
       RTRUE           
L0007: PRINT           "You must tell me how to do that to a "
       PRINT_OBJ       G76
       PRINT_RET       "."

Routine R0160, 1 local (0000)
    Action routine for:
        "chuck OBJ OBJ"

       JE              G77,#f8 [FALSE] L0002
       GET_PARENT      G6f -> L00
       TEST_ATTR       L00,#1b [FALSE] L0001
       GET_PARENT      L00 -> -(SP)
       INSERT_OBJ      G76,(SP)+
       PRINT           "Ahoy -- "
       PRINT_OBJ       G76
       PRINT_RET       " overboard!"
L0001: PRINT_RET       "You're not in anything!"
L0002: PRINT_RET       "Huh?"

Routine R0161, 0 locals ()
    Action routine for:
        "pick OBJ with OBJ"
        "pick OBJ"

       PRINT_RET       "You can't pick that."

Routine R0162, 0 locals ()
    Action routine for:
        "play OBJ"

       PRINT_RET       "That's silly!"

Routine R0163, 0 locals ()
    Action routine for:
        "fix OBJ with OBJ"

       PRINT_RET       "This has no effect."

Routine R0164, 0 locals ()
    Action routine for:
        "pour OBJ on OBJ"

       JE              G76,#ed [FALSE] L0002
       CALL            R0116 (G76) -> -(SP)
       TEST_ATTR       G77,#19 [FALSE] L0001
       TEST_ATTR       G77,#14 [FALSE] L0001
       PRINT           "The "
       PRINT_OBJ       G77
       PRINT           " is extinguished."
       NEW_LINE        
       CLEAR_ATTR      G77,#14
       CLEAR_ATTR      G77,#19
       RTRUE           
L0001: PRINT           "The water spills over the "
       PRINT_OBJ       G77
       PRINT_RET       ", to the floor, and evaporates."
L0002: JE              G76,#62 [FALSE] L0003
       CALL            R0026 (#12,#62,G77) -> -(SP)
       RET_POPPED      
L0003: PRINT_RET       "You can't pour that."

Routine R0165, 0 locals ()
    Action routine for:
        "pray"

       JE              G00,#d4 [FALSE] L0001
       CALL            R0244 (#4e) -> -(SP)
       RET_POPPED      
L0001: PRINT_RET       "If you pray enough, your prayers may be answered."

Routine R0166, 0 locals ()
    Action routine for:
        "pump up OBJ with OBJ"
        "pump up OBJ"

       JZ              G77 [TRUE] L0001
       JE              G77,#ad [TRUE] L0001
       PRINT           "Pump it up with a "
       PRINT_OBJ       G77
       PRINT_RET       "?"
L0001: JIN             "hand-held air pump",G6f [FALSE] L0002
       CALL            R0026 (#17,G76,#ad) -> -(SP)
       RET_POPPED      
L0002: PRINT_RET       "It's really not clear how."

Routine R0167, 0 locals ()
    Action routine for:
        "press on OBJ"
        "press OBJ"

       CALL            R0242 (S171) -> -(SP)
       RET_POPPED      

Routine R0168, 0 locals ()
    Action routine for:
        "slide OBJ to OBJ"
        "slide OBJ OBJ"
        "press OBJ to OBJ"
        "press OBJ OBJ"

       PRINT_RET       "You can't push things to that."

Routine R0169, 0 locals ()
    Pre-action routine for:
        "chuck OBJ in OBJ"
        "squeez OBJ on OBJ"
        "hide OBJ in OBJ"
        "move OBJ in OBJ"
        "drop OBJ in OBJ"
        "drop OBJ down OBJ"
        "apply OBJ to OBJ"
        "chuck OBJ on OBJ"
        "hide OBJ on OBJ"
        "drop OBJ on OBJ"

       CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RFALSE
       CALL            R0126 -> -(SP)
       RET_POPPED      

Routine R0170, 1 local (0000)
    Action routine for:
        "chuck OBJ in OBJ"
        "squeez OBJ on OBJ"
        "hide OBJ in OBJ"
        "move OBJ in OBJ"
        "drop OBJ in OBJ"
        "drop OBJ down OBJ"
        "apply OBJ to OBJ"

       TEST_ATTR       G77,#0b [TRUE] L0003
       TEST_ATTR       G77,#17 [TRUE] L0001
       TEST_ATTR       G77,#13 [TRUE] L0003
L0001: TEST_ATTR       G77,#1b [FALSE] L0002
       JUMP            L0003
L0002: PRINT_RET       "You can't do that."
L0003: TEST_ATTR       G77,#0b [TRUE] L0004
       PRINT           "The "
       PRINT_OBJ       G77
       PRINT           " isn't open."
       NEW_LINE        
       CALL            R0255 (G77) -> -(SP)
       RET_POPPED      
L0004: JE              G77,G76 [FALSE] L0005
       PRINT_RET       "How can you do that?"
L0005: JIN             G76,G77 [FALSE] L0006
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " is already in the "
       PRINT_OBJ       G77
       PRINT_RET       "."
L0006: CALL            R0241 (G77) -> L00
       CALL            R0241 (G76) -> -(SP)
       ADD             L00,(SP)+ -> L00
       GET_PROP        G77,#0f -> -(SP)
       SUB             L00,(SP)+ -> L00
       GET_PROP        G77,#0a -> -(SP)
       JG              L00,(SP)+ [FALSE] L0007
       PRINT_RET       "There's no room."
L0007: CALL            R0252 (G76) -> -(SP)
       JZ              (SP)+ [FALSE] L0008
       TEST_ATTR       G76,#0d [FALSE] L0008
       PRINT           "You don't have the "
       PRINT_OBJ       G76
       PRINT_RET       "."
L0008: CALL            R0252 (G76) -> -(SP)
       JZ              (SP)+ [FALSE] L0009
       CALL            R0238 -> -(SP)
       JZ              (SP)+ [TRUE] RTRUE
L0009: INSERT_OBJ      G76,G77
       SET_ATTR        G76,#03
       CALL            R0235 (G76) -> -(SP)
       PRINT_RET       "Done."

Routine R0171, 0 locals ()
    Action routine for:
        "hide OBJ behind OBJ"

       PRINT_RET       "That hiding place is too obvious."

Routine R0172, 0 locals ()
    Action routine for:
        "chuck OBJ on OBJ"
        "hide OBJ on OBJ"
        "drop OBJ on OBJ"

       JE              G77,#08 [FALSE] L0001
       CALL            R0026 (#31,G76) -> -(SP)
       RTRUE           
L0001: TEST_ATTR       G77,#0a [FALSE] L0002
       CALL            R0170 -> -(SP)
       RET_POPPED      
L0002: PRINT           "There's no good surface on the "
       PRINT_OBJ       G77
       PRINT_RET       "."

Routine R0173, 0 locals ()
    Action routine for:
        "slide OBJ under OBJ"
        "hide OBJ under OBJ"
        "press OBJ under OBJ"

       PRINT_RET       "You can't do that."

Routine R0174, 0 locals ()
    Action routine for:
        "lift up OBJ"
        "lift OBJ"

       CALL            R0149 -> -(SP)
       RET_POPPED      

Routine R0175, 0 locals ()
    Action routine for:
        "molest OBJ"

       PRINT_RET       "What a (ahem!) strange idea."

Routine R0176, 0 locals ()
    Pre-action routine for:
        "read OBJ with OBJ"
        "read from OBJ"
        "read OBJ"
        "gaze at OBJ with OBJ"

       JZ              G42 [FALSE] L0001
       PRINT_RET       "It is impossible to read in the dark."
L0001: JZ              G77 [TRUE] RFALSE
       TEST_ATTR       G77,#0c [TRUE] RFALSE
       PRINT           "How does one look through a "
       PRINT_OBJ       G77
       PRINT_RET       "?"

Routine R0177, 0 locals ()
    Action routine for:
        "read OBJ with OBJ"
        "read from OBJ"
        "read OBJ"
        "gaze at OBJ with OBJ"

       TEST_ATTR       G76,#10 [TRUE] L0001
       PRINT           "How does one read a "
       PRINT_OBJ       G76
       PRINT_RET       "?"
L0001: GET_PROP        G76,#08 -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           

Routine R0178, 0 locals ()
    Action routine for:
        "read OBJ OBJ"

       CALL            R0026 (#53,G76) -> -(SP)
       RTRUE           

Routine R0179, 0 locals ()
    Action routine for:
        "repent"

       PRINT_RET       "It could very well be too late!"

Routine R0180, 0 locals ()
    Action routine for:
        "answer OBJ"

       PRINT           "It is hardly likely that the "
       PRINT_OBJ       G76
       PRINT           " is interested."
       NEW_LINE        
       STORE           G6c,#00
       STORE           G60,#00
       RTRUE           

Routine R0181, 0 locals ()
    Action routine for:
        "peal OBJ with OBJ"
        "peal OBJ"

       PRINT_RET       "How, exactly, can you ring that?"

Routine R0182, 0 locals ()
    Action routine for:
        "feel OBJ with OBJ"
        "feel OBJ"

       CALL            R0242 (S172) -> -(SP)
       RET_POPPED      

Routine R0183, 1 local (0000)
    Action routine for:
        "say"

       JZ              G6c [FALSE] L0001
       PRINT_RET       "Say what?"
L0001: STORE           G60,#00
       RTRUE           

orphan code fragment:

       CALL            R0250 (G00,#1e) -> L00
       JZ              L00 [TRUE] L0002
       PRINT           "You must address the "
       PRINT_OBJ       L00
       PRINT           " directly."
       NEW_LINE        
       STORE           G60,#00
       STORE           G6c,#00
       RET             G6c
L0002: LOADW           G6e,G6c -> -(SP)
       JE              (SP)+,"hello" [FALSE] L0003
       STORE           G60,#00
       RTRUE           
L0003: STORE           G60,#00
       STORE           G6c,#00
       PRINT_RET       "Talking to yourself is a sign of impending mental
collapse."

Routine R0184, 0 locals ()
    Action routine for:
        "search in OBJ"
        "search OBJ"

       PRINT_RET       "You find nothing unusual."

Routine R0185, 0 locals ()
    Action routine for:
        "send for OBJ"

       TEST_ATTR       G76,#1e [FALSE] L0001
       PRINT           "Why would you send for the "
       PRINT_OBJ       G76
       PRINT_RET       "?"
L0001: PRINT_RET       "That doesn't make sends."

Routine R0186, 0 locals ()
    Pre-action routine for:
        "hand OBJ OBJ"
        "donate OBJ OBJ"

       CALL            R0026 (#3f,G77,G76) -> -(SP)
       RTRUE           

Routine R0187, 0 locals ()
    Action routine for:
        "hand OBJ OBJ"
        "donate OBJ OBJ"

       PRINT_RET       "Foo!"

Routine R0188, 0 locals ()
    Action routine for:
        "shake OBJ"

       TEST_ATTR       G76,#1e [FALSE] L0001
       PRINT_RET       "This seems to have no effect."
L0001: TEST_ATTR       G76,#11 [TRUE] L0002
       PRINT_RET       "You can't take it; thus, you can't shake it!"
L0002: TEST_ATTR       G76,#13 [FALSE] L0008
       TEST_ATTR       G76,#0b [FALSE] L0006
       GET_CHILD       G76 -> -(SP) [FALSE] L0005
       CALL            R0189 -> -(SP)
       PRINT           "The contents of the "
       PRINT_OBJ       G76
       PRINT           " spills "
       TEST_ATTR       G00,#06 [TRUE] L0003
       PRINT           "out and disappears"
       JUMP            L0004
L0003: PRINT           "to the ground"
L0004: PRINT_RET       "."
L0005: PRINT_RET       "Shaken."
L0006: GET_CHILD       G76 -> -(SP) [FALSE] L0007
       PRINT           "It sounds like there is something inside the "
       PRINT_OBJ       G76
       PRINT_RET       "."
L0007: PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " sounds empty."
L0008: PRINT_RET       "Shaken."

Routine R0189, 1 local (0000)

L0001: GET_CHILD       G76 -> L00 [FALSE] RTRUE
       SET_ATTR        L00,#03
       JE              G00,#58 [FALSE] L0002
       PUSH            #4b
       JUMP            L0004
L0002: TEST_ATTR       G00,#06 [TRUE] L0003
       PUSH            #0d
       JUMP            L0004
L0003: PUSH            G00
L0004: INSERT_OBJ      L00,(SP)+
       JUMP            L0001

Routine R0190, 0 locals ()
    Action routine for:
        "hop"

       CALL            R0004 (G43) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           

Routine R0191, 0 locals ()
    Action routine for:
        "smell OBJ"

       PRINT           "It smells like a "
       PRINT_OBJ       G76
       PRINT_RET       "."

Routine R0192, 0 locals ()
    Action routine for:
        "spin OBJ"

       PRINT_RET       "You can't spin that!"

Routine R0193, 0 locals ()
    Action routine for:
        "spray OBJ on OBJ"

       CALL            R0194 -> -(SP)
       RET_POPPED      

Routine R0194, 0 locals ()
    Action routine for:
        "squeez OBJ"

       TEST_ATTR       G76,#1e [FALSE] L0001
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " does not understand this."
       JUMP            L0002
L0001: PRINT           "How singularly useless."
L0002: NEW_LINE        
       RTRUE           

Routine R0195, 0 locals ()
    Action routine for:
        "spray OBJ with OBJ"

       CALL            R0026 (#77,G77,G76) -> -(SP)
       RET_POPPED      

Routine R0196, 1 local (0000)
    Action routine for:
        "stab OBJ"

       CALL            R0413 (G6f) -> L00
       JZ              L00 [TRUE] L0001
       CALL            R0026 (#13,G76,L00) -> -(SP)
       RTRUE           
L0001: PRINT           "No doubt you propose to stab the "
       PRINT_OBJ       G76
       PRINT_RET       " with your pinky?"

Routine R0197, 0 locals ()
    Action routine for:
        "carry up OBJ"
        "stand up OBJ"
        "stand"

       GET_PARENT      G6f -> -(SP)
       TEST_ATTR       (SP)+,#1b [FALSE] L0001
       GET_PARENT      G6f -> -(SP)
       CALL            R0026 (#2d,(SP)+) -> -(SP)
       RTRUE           
L0001: PRINT_RET       "You are already standing, I think."

Routine R0198, 0 locals ()
    Action routine for:
        "stay"

       PRINT_RET       "You will be lost without me!"

Routine R0199, 0 locals ()
    Action routine for:
        "strike OBJ"

       TEST_ATTR       G76,#1e [FALSE] L0001
       PRINT           "Since you aren't versed in hand-to-hand combat, you'd
better attack the "
       PRINT_OBJ       G76
       PRINT_RET       " with a weapon."
L0001: CALL            R0026 (#0e,G76) -> -(SP)
       RTRUE           

Routine R0200, 0 locals ()
    Action routine for:
        "bathe in OBJ"
        "bathe"

       CALL            R0249 (#ee,G00) -> -(SP)
       JZ              (SP)+ [TRUE] L0003
       PRINT           "Swimming isn't usually allowed in the "
       JZ              G76 [TRUE] L0001
       PRINT_OBJ       G76
       PRINT           "."
       JUMP            L0002
L0001: PRINT           "dungeon."
L0002: NEW_LINE        
       RTRUE           
L0003: CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RFALSE
       PRINT_RET       "Go jump in a lake!"

Routine R0201, 0 locals ()
    Action routine for:
        "swing OBJ at OBJ"
        "swing OBJ"

       JZ              G77 [FALSE] L0001
       PRINT_RET       "Whoosh!"
L0001: CALL            R0026 (#13,G77,G76) -> -(SP)
       RET_POPPED      

Routine R0202, 0 locals ()
    Pre-action routine for:
        "carry OBJ from OBJ"
        "carry OBJ off OBJ"
        "carry OBJ out OBJ"
        "carry OBJ"
        "pick up OBJ"

       JIN             G76,G6f [FALSE] L0002
       TEST_ATTR       G76,#00 [FALSE] L0001
       PRINT_RET       "You are already wearing it."
L0001: PRINT_RET       "You already have that!"
L0002: GET_PARENT      G76 -> -(SP)
       TEST_ATTR       (SP)+,#13 [FALSE] L0003
       GET_PARENT      G76 -> -(SP)
       TEST_ATTR       (SP)+,#0b [TRUE] L0003
       PRINT_RET       "You can't reach something that's inside a closed
container."
L0003: JZ              G77 [TRUE] L0006
       JE              G77,#08 [FALSE] L0004
       STORE           G77,#00
       RFALSE          
L0004: GET_PARENT      G76 -> -(SP)
       JE              G77,(SP)+ [TRUE] L0005
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " isn't in the "
       PRINT_OBJ       G77
       PRINT_RET       "."
L0005: STORE           G77,#00
       RFALSE          
L0006: GET_PARENT      G6f -> -(SP)
       JE              G76,(SP)+ [FALSE] RFALSE
       PRINT_RET       "You're inside of it!"

Routine R0203, 0 locals ()
    Action routine for:
        "carry OBJ from OBJ"
        "carry OBJ off OBJ"
        "carry OBJ out OBJ"
        "carry OBJ"
        "pick up OBJ"

       CALL            R0238 -> -(SP)
       JE              (SP)+,#01 [FALSE] RFALSE
       TEST_ATTR       G76,#00 [FALSE] L0001
       PRINT           "You are now wearing the "
       PRINT_OBJ       G76
       PRINT_RET       "."
L0001: PRINT_RET       "Taken."

Routine R0204, 0 locals ()
    Action routine for:
        "ask OBJ"
        "talk to OBJ"

       TEST_ATTR       G76,#1e [FALSE] L0002
       JZ              G6c [TRUE] L0001
       STORE           G6f,G76
       GET_PARENT      G6f -> G00
       RET             G00
L0001: PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " pauses for a moment, perhaps thinking that you should
re-read the manual."
L0002: PRINT           "You can't talk to the "
       PRINT_OBJ       G76
       PRINT           "!"
       NEW_LINE        
       STORE           G60,#00
       STORE           G6c,#00
       RET             #02

Routine R0205, 2 locals (0000, 0000)
    Action routine for:
        "go on OBJ"
        "go with OBJ"
        "go in OBJ"
        "enter OBJ"
        "climb with OBJ"

       TEST_ATTR       G76,#17 [FALSE] L0001
       CALL            R0253 (G76) -> -(SP)
       CALL            R0247 ((SP)+) -> -(SP)
       RTRUE           
L0001: JZ              L00 [FALSE] L0002
       TEST_ATTR       G76,#1b [FALSE] L0002
       CALL            R0026 (#19,G76) -> -(SP)
       RTRUE           
L0002: JZ              L00 [FALSE] L0003
       TEST_ATTR       G76,#11 [TRUE] L0003
       CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RTRUE
       CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RTRUE
       CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RTRUE
       CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RTRUE
       PRINT           "You hit your head against the "
       PRINT_OBJ       G76
       PRINT_RET       " as you attempt this feat."
L0003: JZ              L00 [TRUE] L0004
       PRINT_RET       "You can't do that!"
L0004: JIN             G76,G6f [FALSE] L0005
       PRINT_RET       "That would involve quite a contortion!"
L0005: CALL            R0004 (G35) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           

Routine R0206, 0 locals ()
    Action routine for:
        "chuck OBJ with OBJ"
        "chuck OBJ at OBJ"

       CALL            R0239 -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       JE              G77,#05 [FALSE] L0001
       PRINT           "A terrific throw! The "
       PRINT_OBJ       G76
       CALL            R0431 (S177) -> -(SP)
       RET_POPPED      
L0001: TEST_ATTR       G77,#1e [FALSE] L0002
       PRINT           "The "
       PRINT_OBJ       G77
       PRINT           " ducks as the "
       PRINT_OBJ       G76
       PRINT_RET       " flies by and crashes to the ground."
L0002: PRINT_RET       "Thrown."

Routine R0207, 0 locals ()
    Action routine for:
        "chuck OBJ over OBJ"
        "chuck OBJ off OBJ"

       PRINT_RET       "You can't throw anything off of that!"

Routine R0208, 0 locals ()
    Action routine for:
        "attach OBJ to OBJ"

       JE              G77,G6f [FALSE] L0001
       PRINT_RET       "You can't tie anything to yourself."
L0001: PRINT           "You can't tie the "
       PRINT_OBJ       G76
       PRINT_RET       " to that."

Routine R0209, 0 locals ()
    Action routine for:
        "attach up OBJ with OBJ"

       PRINT_RET       "You could certainly never tie it with that!"

Routine R0210, 0 locals ()
    Action routine for:
        "temple"

       JE              G00,#dc [FALSE] L0001
       CALL            R0244 (#be) -> -(SP)
       RET_POPPED      
L0001: JE              G00,#be [FALSE] L0002
       CALL            R0244 (#dc) -> -(SP)
       RET_POPPED      
L0002: PRINT_RET       "Nothing happens."

Routine R0211, 0 locals ()
    Pre-action routine for:
        "flip OBJ for OBJ"
        "flip OBJ to OBJ"
        "flip OBJ with OBJ"
        "press OBJ with OBJ"
        "move OBJ with OBJ"

       TEST_ATTR       G76,#0f [TRUE] RFALSE
       PRINT_RET       "You can't turn that!"

Routine R0212, 0 locals ()
    Action routine for:
        "flip OBJ for OBJ"
        "flip OBJ to OBJ"
        "flip OBJ with OBJ"
        "press OBJ with OBJ"
        "move OBJ with OBJ"

       PRINT_RET       "This has no effect."

Routine R0213, 0 locals ()
    Action routine for:
        "unlock OBJ with OBJ"

       CALL            R0143 -> -(SP)
       RET_POPPED      

Routine R0214, 0 locals ()
    Action routine for:
        "free OBJ from OBJ"
        "free OBJ"

       PRINT_RET       "This cannot be tied, so it cannot be untied!"

Routine R0215, 1 local (0003)
    Action routine for:
        "wait"

       PRINT           "Time passes..."
       NEW_LINE        
L0001: DEC_CHK         L00,#00 [FALSE] L0002
       JUMP            L0003
L0002: CALL            R0024 -> -(SP)
       JZ              (SP)+ [TRUE] L0001
L0003: STORE           G81,#01
       RET             G81

Routine R0216, 5 locals (0000, 0000, 0000, 0000, 0000)
    Action routine for:
        "go away OBJ"
        "go OBJ"

       JZ              G5f [FALSE] L0001
       CALL            R0026 (#8a,G76) -> -(SP)
       RTRUE           
L0001: GET_PROP_ADDR   G00,G76 -> L00
       JZ              L00 [TRUE] L0011
       GET_PROP_LEN    L00 -> L01
       JE              L01,#01 [FALSE] L0002
       LOADB           L00,#00 -> -(SP)
       CALL            R0244 ((SP)+) -> -(SP)
       RET_POPPED      
L0002: JE              L01,#02 [FALSE] L0003
       LOADW           L00,#00 -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RET             #02
L0003: JE              L01,#03 [FALSE] L0005
       LOADW           L00,#00 -> -(SP)
       CALL            (SP)+ -> L04
       JZ              L04 [TRUE] L0004
       CALL            R0244 (L04) -> -(SP)
       RET_POPPED      
L0004: CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RFALSE
       RET             #02
L0005: JE              L01,#04 [FALSE] L0008
       LOADB           L00,#01 -> -(SP)
       LOAD            [(SP)+] -> -(SP)
       JZ              (SP)+ [TRUE] L0006
       LOADB           L00,#00 -> -(SP)
       CALL            R0244 ((SP)+) -> -(SP)
       RET_POPPED      
L0006: LOADW           L00,#01 -> L02
       JZ              L02 [TRUE] L0007
       PRINT_PADDR     L02
       NEW_LINE        
       RET             #02
L0007: PRINT           "You can't go that way."
       NEW_LINE        
       RET             #02
L0008: JE              L01,#05 [FALSE] RFALSE
       LOADB           L00,#01 -> L03
       TEST_ATTR       L03,#0b [FALSE] L0009
       LOADB           L00,#00 -> -(SP)
       CALL            R0244 ((SP)+) -> -(SP)
       RET_POPPED      
L0009: LOADW           L00,#01 -> L02
       JZ              L02 [TRUE] L0010
       PRINT_PADDR     L02
       NEW_LINE        
       RET             #02
L0010: PRINT           "The "
       PRINT_OBJ       L03
       PRINT           " is closed."
       NEW_LINE        
       CALL            R0255 (L03) -> -(SP)
       RET             #02
L0011: JZ              G42 [FALSE] L0013
       RANDOM          #64 -> -(SP)
       JG              #50,(SP)+ [FALSE] L0013
       TEST_ATTR       G00,#04 [TRUE] L0013
       JZ              G41 [TRUE] L0012
       PRINT           "There are odd noises in the darkness, and there is no
exit in that direction."
       NEW_LINE        
       RET             #02
L0012: CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RFALSE
       CALL            R0431 (S178) -> -(SP)
       RET_POPPED      
L0013: PRINT           "You can't go that way."
       NEW_LINE        
       RET             #02

Routine R0217, 0 locals ()
    Action routine for:
        "go around OBJ"

       PRINT_RET       "Use compass directions for movement."

Routine R0218, 0 locals ()
    Action routine for:
        "go to OBJ"

       JIN             G76,G00 [TRUE] L0001
       CALL            R0249 (G76,G00) -> -(SP)
       JZ              (SP)+ [TRUE] L0002
L0001: PRINT_RET       "It's here!"
L0002: PRINT_RET       "You should supply a direction!"

Routine R0219, 0 locals ()
    Action routine for:
        "brandi OBJ at OBJ"
        "brandi OBJ"

       CALL            R0242 (S179) -> -(SP)
       RET_POPPED      

Routine R0220, 0 locals ()
    Action routine for:
        "wear OBJ"
        "hide on OBJ"

       TEST_ATTR       G76,#00 [TRUE] L0001
       PRINT           "You can't wear the "
       PRINT_OBJ       G76
       PRINT_RET       "."
L0001: CALL            R0026 (#5d,G76) -> -(SP)
       RTRUE           

Routine R0221, 0 locals ()
    Action routine for:
        "win"

       PRINT_RET       "Naturally!"

Routine R0222, 0 locals ()
    Action routine for:
        "wind up OBJ"
        "wind OBJ"

       PRINT           "You cannot wind up a "
       PRINT_OBJ       G76
       PRINT_RET       "."

Routine R0223, 0 locals ()
    Action routine for:
        "wish"

       PRINT_RET       "With luck, your wish will come true."

Routine R0224, 0 locals ()
    Action routine for:
        "scream"

       PRINT_RET       "Aaaarrrrgggghhhh!"

Routine R0225, 0 locals ()
    Action routine for:
        "zork"

       PRINT_RET       "At your service!"

Routine R0226, 0 locals ()

       CALL            R0227 -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       JZ              G46 [FALSE] RFALSE
       CALL            R0228 -> -(SP)
       RET_POPPED      

Routine R0227, 4 locals (0000, 0000, 0000, 0000)

       JZ              L00 [TRUE] L0001
       PUSH            L00
       JUMP            L0002
L0001: PUSH            G47
L0002: PULL            L01
       JZ              G42 [FALSE] L0004
       PRINT           "It is pitch black."
       JZ              G41 [FALSE] L0003
       PRINT           " You are likely to be eaten by a grue."
L0003: NEW_LINE        
       CALL            R0013 -> -(SP)
       RET             #00
L0004: TEST_ATTR       G00,#03 [TRUE] L0005
       SET_ATTR        G00,#03
       STORE           L01,#01
L0005: TEST_ATTR       G00,#05 [FALSE] L0006
       CLEAR_ATTR      G00,#03
L0006: JIN             G00,#52 [FALSE] L0008
       PRINT_OBJ       G00
       GET_PARENT      G6f -> L03
       TEST_ATTR       L03,#1b [FALSE] L0007
       PRINT           ", in the "
       PRINT_OBJ       L03
L0007: NEW_LINE        
L0008: JZ              L00 [FALSE] L0009
       JZ              G46 [FALSE] RTRUE
L0009: GET_PARENT      G6f -> L03
       JZ              L01 [TRUE] L0010
       GET_PROP        G00,#11 -> -(SP)
       CALL            (SP)+ (#03) -> -(SP)
       JZ              (SP)+ [FALSE] RTRUE
L0010: JZ              L01 [TRUE] L0011
       GET_PROP        G00,#0b -> L02
       JZ              L02 [TRUE] L0011
       PRINT_PADDR     L02
       NEW_LINE        
       JUMP            L0012
L0011: GET_PROP        G00,#11 -> -(SP)
       CALL            (SP)+ (#04) -> -(SP)
L0012: JE              G00,L03 [TRUE] RTRUE
       TEST_ATTR       L03,#1b [FALSE] RTRUE
       GET_PROP        L03,#11 -> -(SP)
       CALL            (SP)+ (#03) -> -(SP)
       RTRUE           

Routine R0228, 1 local (0000)

       JZ              G42 [TRUE] L0003
       GET_CHILD       G00 -> -(SP) [FALSE] RFALSE
       JZ              L00 [TRUE] L0001
       PUSH            L00
       JUMP            L0002
L0001: PUSH            G47
L0002: PULL            L00
       CALL            R0231 (G00,L00,#ffff) -> -(SP)
       RET_POPPED      
L0003: PRINT_RET       "Only bats can see in the dark. And you're not one."

Routine R0229, 5 locals (0000, 0000, 0000, 0000, 0000)

       STORE           G40,L00
       JZ              L02 [FALSE] L0001
       GET_PROP        L00,#09 -> -(SP)
       CALL            (SP)+ (#05) -> -(SP)
       JZ              (SP)+ [FALSE] RTRUE
L0001: JZ              L02 [FALSE] L0004
       TEST_ATTR       L00,#03 [TRUE] L0002
       GET_PROP        L00,#0e -> L03
       JZ              L03 [FALSE] L0003
L0002: GET_PROP        L00,#0b -> L03
       JZ              L03 [TRUE] L0004
L0003: PRINT_PADDR     L03
       JUMP            L0008
L0004: JZ              L02 [FALSE] L0006
       PRINT           "There is a "
       PRINT_OBJ       L00
       PRINT           " here"
       TEST_ATTR       L00,#14 [FALSE] L0005
       PRINT           " (providing light)"
L0005: PRINT           "."
       JUMP            L0008
L0006: LOADW           G39,L02 -> -(SP)
       PRINT_PADDR     (SP)+
       PRINT           "A "
       PRINT_OBJ       L00
       TEST_ATTR       L00,#14 [FALSE] L0007
       PRINT           " (providing light)"
       JUMP            L0008
L0007: TEST_ATTR       L00,#00 [FALSE] L0008
       PRINT           " (being worn)"
L0008: CALL            R0013 -> -(SP)
       JZ              L02 [FALSE] L0009
       GET_PARENT      G6f -> L04
       JZ              L04 [TRUE] L0009
       TEST_ATTR       L04,#1b [FALSE] L0009
       PRINT           " (outside the "
       PRINT_OBJ       L04
       PRINT           ")"
L0009: NEW_LINE        
       CALL            R0233 (L00) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       GET_CHILD       L00 -> -(SP) [FALSE] RFALSE
       CALL            R0231 (L00,L01,L02) -> -(SP)
       RET_POPPED      

Routine R0230, 6 locals (0000, 0000, 0000, 0001, 0000, 0000)

       GET_CHILD       L00 -> L01 [FALSE] RFALSE
L0001: GET_SIBLING     L01 -> L02 [TRUE] L0002
L0002: JZ              L03 [TRUE] L0003
       STORE           L03,#00
       JUMP            L0004
L0003: PRINT           ", "
       JZ              L02 [FALSE] L0004
       PRINT           "and "
L0004: PRINT           "a "
       PRINT_OBJ       L01
       JZ              L04 [FALSE] L0005
       JZ              L05 [FALSE] L0005
       STORE           L04,L01
       JUMP            L0006
L0005: STORE           L05,#01
       STORE           L04,#00
L0006: STORE           L01,L02
       JZ              L01 [FALSE] L0001
       JZ              L04 [TRUE] RTRUE
       JZ              L05 [FALSE] RTRUE
       CALL            R0255 (L04) -> -(SP)
       RTRUE           

Routine R0231, 10 locals (0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000,
                          0000)

       GET_CHILD       L00 -> L03 [FALSE] RTRUE
       GET_PARENT      G6f -> L06
       JZ              L06 [TRUE] L0001
       TEST_ATTR       L06,#1b [FALSE] L0001
       JUMP            L0002
L0001: STORE           L06,#00
L0002: STORE           L04,#01
       STORE           L05,#01
       GET_PARENT      L00 -> -(SP)
       JE              G6f,L00,(SP)+ [FALSE] L0003
       STORE           L09,#01
       JUMP            L0010
L0003: JZ              L03 [FALSE] L0004
       JUMP            L0010
L0004: JE              L03,L06 [FALSE] L0005
       STORE           L08,#01
       JUMP            L0008
L0005: JE              L03,G6f [FALSE] L0006
       JUMP            L0008
L0006: TEST_ATTR       L03,#07 [TRUE] L0008
       TEST_ATTR       L03,#03 [TRUE] L0008
       GET_PROP        L03,#0e -> L07
       JZ              L07 [TRUE] L0008
       TEST_ATTR       L03,#0e [TRUE] L0007
       PRINT_PADDR     L07
       NEW_LINE        
       STORE           L05,#00
L0007: CALL            R0233 (L03) -> -(SP)
       JZ              (SP)+ [TRUE] L0008
       GET_PARENT      L03 -> -(SP)
       GET_PROP        (SP)+,#09 -> -(SP)
       JZ              (SP)+ [FALSE] L0008
       GET_CHILD       L03 -> -(SP) [FALSE] L0008
       CALL            R0231 (L03,L01,#00) -> -(SP)
       JZ              (SP)+ [TRUE] L0008
       STORE           L04,#00
L0008: GET_SIBLING     L03 -> L03 [TRUE] L0009
L0009: JUMP            L0003
L0010: GET_CHILD       L00 -> L03 [TRUE] L0011
L0011: JZ              L03 [FALSE] L0012
       JZ              L08 [TRUE] L0021
       JZ              L06 [TRUE] L0021
       GET_CHILD       L06 -> -(SP) [FALSE] L0021
       INC             L02
       CALL            R0231 (L06,L01,L02) -> -(SP)
       JUMP            L0021
L0012: JE              L03,L06,#04 [FALSE] L0013
       JUMP            L0019
L0013: TEST_ATTR       L03,#07 [TRUE] L0019
       JZ              L09 [FALSE] L0014
       TEST_ATTR       L03,#03 [TRUE] L0014
       GET_PROP        L03,#0e -> -(SP)
       JZ              (SP)+ [FALSE] L0019
L0014: TEST_ATTR       L03,#0e [TRUE] L0018
       JZ              L04 [TRUE] L0016
       CALL            R0232 (L00,L02) -> -(SP)
       JZ              (SP)+ [TRUE] L0015
       JL              L02,#00 [FALSE] L0015
       STORE           L02,#00
L0015: INC             L02
       STORE           L04,#00
L0016: JL              L02,#00 [FALSE] L0017
       STORE           L02,#00
L0017: CALL            R0229 (L03,L01,L02) -> -(SP)
       JUMP            L0019
L0018: GET_CHILD       L03 -> -(SP) [FALSE] L0019
       CALL            R0233 (L03) -> -(SP)
       JZ              (SP)+ [TRUE] L0019
       INC             L02
       CALL            R0231 (L03,L01,L02) -> -(SP)
L0019: GET_SIBLING     L03 -> L03 [TRUE] L0020
L0020: JUMP            L0011
L0021: JZ              L04 [TRUE] RTRUE
       JZ              L05 [TRUE] RTRUE
       RFALSE          

Routine R0232, 2 locals (0000, 0000)

       JE              L00,#c2 [FALSE] L0001
       PRINT_RET       "Your collection of treasures consists of:"
L0001: JE              L00,G6f [FALSE] L0002
       PRINT_RET       "You are carrying:"
L0002: JIN             L00,#52 [TRUE] RFALSE
       JG              L01,#00 [FALSE] L0003
       LOADW           G39,L01 -> -(SP)
       PRINT_PADDR     (SP)+
L0003: TEST_ATTR       L00,#0a [FALSE] L0004
       PRINT           "Sitting on the "
       PRINT_OBJ       L00
       PRINT_RET       " is: "
L0004: TEST_ATTR       L00,#1e [FALSE] L0005
       PRINT           "The "
       PRINT_OBJ       L00
       PRINT_RET       " is holding: "
L0005: PRINT           "The "
       PRINT_OBJ       L00
       PRINT_RET       " contains:"

Routine R0233, 1 local (0000)

       TEST_ATTR       L00,#07 [TRUE] RFALSE
       TEST_ATTR       L00,#0c [TRUE] RTRUE
       TEST_ATTR       L00,#0b [TRUE] RTRUE
       RFALSE          

Routine R0234, 1 local (0000)

       ADD             G3f,L00 -> G3f
       ADD             G01,L00 -> G01
       JE              G01,#015e [FALSE] RTRUE
       JZ              G8c [FALSE] RTRUE
       STORE           G8c,#01
       CLEAR_ATTR      "ancient map",#07
       CLEAR_ATTR      "West of House",#03
       PRINT_RET       "An almost inaudible voice whispers in your ear, "Look
to your treasures for the final secret.""

Routine R0235, 2 locals (0000, 0000)

       GET_PROP        L00,#0d -> L01
       JG              L01,#00 [FALSE] RFALSE
       CALL            R0234 (L01) -> -(SP)
       PUT_PROP        L00,#0d,#00
       RTRUE           

Routine R0236, 0 locals ()

       CALL            R0430 -> -(SP)
       QUIT            

Routine R0237, 0 locals ()

       PRINT           ">"
       READ            G6d,G6e
       LOADW           G6e,#01 -> -(SP)
       JE              (SP)+,"yes","y" [FALSE] RFALSE
       RTRUE           

Routine R0238, 4 locals (0001, 0000, 0000, 0000)

       JZ              G3e [TRUE] L0001
       JZ              L00 [TRUE] RFALSE
       PRINT           "Your hand passes through its object."
       NEW_LINE        
       RFALSE          
L0001: TEST_ATTR       G76,#11 [TRUE] L0002
       JZ              L00 [TRUE] RFALSE
       CALL            R0004 (G35) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RFALSE          
L0002: CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RFALSE
       GET_PARENT      G76 -> -(SP)
       TEST_ATTR       (SP)+,#13 [FALSE] L0003
       GET_PARENT      G76 -> -(SP)
       TEST_ATTR       (SP)+,#0b [FALSE] RFALSE
L0003: GET_PARENT      G76 -> -(SP)
       JIN             (SP)+,G6f [TRUE] L0007
       CALL            R0241 (G76) -> L03
       CALL            R0241 (G6f) -> -(SP)
       ADD             L03,(SP)+ -> -(SP)
       JG              (SP)+,G85 [FALSE] L0007
       JZ              L00 [TRUE] L0006
       PRINT           "Your load is too heavy"
       JL              G85,G86 [FALSE] L0004
       PRINT           ", especially in light of your condition."
       JUMP            L0005
L0004: PRINT           "."
L0005: NEW_LINE        
L0006: RET             #02
L0007: JE              G78,#5d [FALSE] L0008
       CALL            R0240 (G6f) -> L01
       JG              L01,G3b [FALSE] L0008
       MUL             L01,G3a -> L03
       RANDOM          #64 -> -(SP)
       JG              L03,(SP)+ [FALSE] L0008
       PRINT           "You're holding too many things already!"
       NEW_LINE        
       RFALSE          
L0008: INSERT_OBJ      G76,G6f
       SET_ATTR        G76,#03
       CALL            R0013 -> -(SP)
       CALL            R0235 (G76) -> -(SP)
       RTRUE           

Routine R0239, 0 locals ()

       JIN             G76,G6f [TRUE] L0001
       GET_PARENT      G76 -> -(SP)
       JIN             (SP)+,G6f [TRUE] L0001
       PRINT           "You're not carrying the "
       PRINT_OBJ       G76
       PRINT           "."
       NEW_LINE        
       RFALSE          
L0001: JIN             G76,G6f [TRUE] L0002
       GET_PARENT      G76 -> -(SP)
       TEST_ATTR       (SP)+,#0b [TRUE] L0002
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " is closed."
       NEW_LINE        
       RFALSE          
L0002: GET_PARENT      G6f -> -(SP)
       INSERT_OBJ      G76,(SP)+
       RTRUE           

Routine R0240, 3 locals (0000, 0000, 0000)

       GET_CHILD       L00 -> L02 [FALSE] L0003
L0001: TEST_ATTR       L02,#00 [TRUE] L0002
       INC             L01
L0002: GET_SIBLING     L02 -> L02 [TRUE] L0001
L0003: RET             L01

Routine R0241, 3 locals (0000, 0000, 0000)

       GET_CHILD       L00 -> L01 [FALSE] L0004
L0001: JE              L00,G80 [FALSE] L0002
       TEST_ATTR       L01,#00 [FALSE] L0002
       INC             L02
       JUMP            L0003
L0002: CALL            R0241 (L01) -> -(SP)
       ADD             L02,(SP)+ -> L02
L0003: GET_SIBLING     L01 -> L01 [TRUE] L0001
L0004: GET_PROP        L00,#0f -> -(SP)
       ADD             L02,(SP)+ -> -(SP)
       RET_POPPED      

Routine R0242, 1 local (0000)

       JIN             G76,#f7 [FALSE] L0001
       JE              G78,#54,#69,#8c [FALSE] L0001
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " isn't here!"
L0001: PRINT_PADDR     L00
       PRINT_OBJ       G76
       CALL            R0004 (G38) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           

Routine R0243, 2 locals (0000, 0000)

       JZ              L00 [TRUE] L0001
       PRINT           "You can't go there in a "
       PRINT_OBJ       L01
       PRINT           "."
       JUMP            L0002
L0001: PRINT           "You can't go there without a vehicle."
L0002: NEW_LINE        
       RTRUE           

Routine R0244, 6 locals (0000, 0001, 0000, 0000, 0000, 0000)

       TEST_ATTR       L00,#06 [TRUE] L0001
       PUSH            #00
       JUMP            L0002
L0001: PUSH            #01
L0002: STORE           L02,(SP)+
       GET_PARENT      G6f -> L03
       STORE           L05,G42
       TEST_ATTR       L03,#1b [FALSE] L0003
       GET_PROP        L03,#06 -> L04
L0003: JZ              L02 [FALSE] L0004
       JZ              L04 [FALSE] L0004
       CALL            R0243 (L04,L03) -> -(SP)
       RFALSE          
L0004: JZ              L02 [FALSE] L0005
       TEST_ATTR       L00,L04 [TRUE] L0005
       CALL            R0243 (L04,L03) -> -(SP)
       RFALSE          
L0005: TEST_ATTR       G00,#06 [FALSE] L0006
       JZ              L02 [TRUE] L0006
       JZ              L04 [TRUE] L0006
       JE              L04,#06 [TRUE] L0006
       TEST_ATTR       L00,L04 [TRUE] L0006
       CALL            R0243 (L04,L03) -> -(SP)
       RFALSE          
L0006: TEST_ATTR       L00,#12 [FALSE] L0007
       GET_PROP        L00,#0b -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RFALSE          
L0007: JZ              L02 [TRUE] L0008
       TEST_ATTR       G00,#06 [TRUE] L0008
       JZ              G3e [FALSE] L0008
       TEST_ATTR       L03,#1b [FALSE] L0008
       PRINT           "The "
       PRINT_OBJ       L03
       PRINT           " comes to a rest on the shore."
       NEW_LINE        
       NEW_LINE        
L0008: JZ              L04 [TRUE] L0009
       INSERT_OBJ      L03,L00
       JUMP            L0010
L0009: INSERT_OBJ      G6f,L00
L0010: STORE           G00,L00
       CALL            R0063 (G00) -> G42
       JZ              L05 [FALSE] L0014
       JZ              G42 [FALSE] L0014
       RANDOM          #64 -> -(SP)
       JG              #50,(SP)+ [FALSE] L0014
       JZ              G41 [TRUE] L0011
       PRINT           "There are sinister gurgling noises in the darkness all
around you!"
       NEW_LINE        
       JUMP            L0014
L0011: CALL            R0013 -> -(SP)
       JZ              (SP)+ [FALSE] RFALSE
       PRINT           "Oh, no! A lurking grue slithered into the "
       GET_PARENT      G6f -> -(SP)
       TEST_ATTR       (SP)+,#1b [FALSE] L0012
       GET_PARENT      G6f -> -(SP)
       PRINT_OBJ       (SP)+
       JUMP            L0013
L0012: PRINT           "room"
L0013: CALL            R0431 (S188) -> -(SP)
       RTRUE           
L0014: JZ              G42 [FALSE] L0015
       JE              G6f,#04 [FALSE] L0015
       PRINT           "You have moved into a dark place."
       NEW_LINE        
       STORE           G6c,#00
L0015: GET_PROP        G00,#11 -> -(SP)
       CALL            (SP)+ (#02) -> -(SP)
       CALL            R0235 (L00) -> -(SP)
       JE              G00,L00 [FALSE] RTRUE
       JE              #04,G6f [TRUE] L0016
       PRINT           "The "
       PRINT_OBJ       G6f
       PRINT_RET       " leaves the room."
L0016: JZ              L01 [TRUE] RTRUE
       CALL            R0226 -> -(SP)
       RTRUE           

Routine R0245, 2 locals (0000, 0000)

       CALL            R0246 (G00,L00) -> L01
       JZ              L01 [TRUE] RFALSE
       CALL            R0244 (L01) -> -(SP)
       JZ              (SP)+ [FALSE] RTRUE
       RET             #02

Routine R0246, 4 locals (0000, 0000, 0000, 0000)

       LOADW           L01,#00 -> L03
L0001: INC_CHK         L02,L03 [TRUE] RFALSE
       LOADW           L01,L02 -> -(SP)
       JE              (SP)+,L00 [FALSE] L0001
       JE              L02,L03 [TRUE] RFALSE
       ADD             L02,#01 -> -(SP)
       LOADW           L01,(SP)+ -> -(SP)
       RET             (SP)+

Routine R0247, 1 local (0000)

       STORE           G5f,L00
       CALL            R0026 (#89,L00) -> -(SP)
       RET_POPPED      

Routine R0248, 4 locals (0000, 0000, 0000, 0000)

       GET_PROP_ADDR   L00,#12 -> L02
       GET_PROP_LEN    L02 -> -(SP)
       DIV             (SP)+,#02 -> -(SP)
       SUB             (SP)+,#01 -> -(SP)
       CALL            R0061 (L01,L02,(SP)+) -> -(SP)
       RET_POPPED      

Routine R0249, 3 locals (0000, 0000, 0000)

       GET_PROP_ADDR   L01,#05 -> L02
       JZ              L02 [TRUE] RFALSE
       GET_PROP_LEN    L02 -> -(SP)
       SUB             (SP)+,#01 -> -(SP)
       CALL            R0062 (L00,L02,(SP)+) -> -(SP)
       RET_POPPED      

Routine R0250, 3 locals (0000, 0000, 0000)

       GET_CHILD       L00 -> L02 [TRUE] L0001
L0001: JZ              L02 [TRUE] RFALSE
L0002: TEST_ATTR       L02,L01 [FALSE] L0003
       JE              L02,#04 [TRUE] L0003
       RET             L02
L0003: GET_SIBLING     L02 -> L02 [TRUE] L0002
       RFALSE          

Routine R0251, 1 local (0000)

       JIN             L00,G00 [TRUE] RTRUE
       CALL            R0249 (L00,G00) -> -(SP)
       RET_POPPED      

Routine R0252, 1 local (0000)

L0001: GET_PARENT      L00 -> L00
       JZ              L00 [TRUE] RFALSE
       JE              L00,G6f [FALSE] L0001
       RTRUE           

Routine R0253, 3 locals (0000, 0000, 0000)

L0001: GET_NEXT_PROP   G00,L01 -> L01
       JL              L01,G98 [TRUE] RFALSE
       GET_PROP_ADDR   G00,L01 -> L02
       GET_PROP_LEN    L02 -> -(SP)
       JE              (SP)+,#05 [FALSE] L0001
       LOADB           L02,#01 -> -(SP)
       JE              (SP)+,L00 [FALSE] L0001
       RET             L01

Routine R0254, 2 locals (0000, 0000)

       SET_ATTR        L00,#12
       PUT_PROP        L00,#0b,L01
       RTRUE           

Routine R0255, 1 local (0000)

       STORE           G6b,L00
       STORE           G6a,G00
       RET             G6a

Routine R0256, 1 local (0000)

       JE              L00,#03 [FALSE] RFALSE
       PRINT           "You are standing in an open field west of a white
house, with a boarded front door."
       JZ              G8c [TRUE] L0001
       PRINT           " A secret path leads southwest into the forest."
L0001: NEW_LINE        
       RTRUE           

Routine R0257, 1 local (0000)

       JE              L00,#03 [FALSE] RFALSE
       PRINT           "You are behind the white house. A path leads into the
forest to the east. In one corner of the house there is a small window which is
"
       TEST_ATTR       "kitchen window",#0b [FALSE] L0001
       PRINT           "open."
       JUMP            L0002
L0001: PRINT           "slightly ajar."
L0002: NEW_LINE        
       RTRUE           

Routine R0258, 3 locals (0000, 0000, 0000)

       JE              G78,#2b [FALSE] L0003
       TEST_ATTR       L00,#0b [FALSE] L0001
       CALL            R0004 (G34) -> -(SP)
       PRINT_PADDR     (SP)+
       JUMP            L0002
L0001: PRINT_PADDR     L01
       SET_ATTR        L00,#0b
L0002: NEW_LINE        
       RTRUE           
L0003: JE              G78,#23 [FALSE] RFALSE
       TEST_ATTR       L00,#0b [FALSE] L0004
       PRINT_PADDR     L02
       CLEAR_ATTR      L00,#0b
       JUMP            L0005
L0004: CALL            R0004 (G34) -> -(SP)
       PRINT_PADDR     (SP)+
L0005: NEW_LINE        
       RTRUE           

Routine R0259, 0 locals ()

       JE              G78,#38,#5d [FALSE] RFALSE
       PRINT_RET       "The boards are securely fastened."

Routine R0260, 0 locals ()

       JE              G78,#1a [FALSE] RFALSE
       JE              G76,#f8 [FALSE] RFALSE
       JE              G77,#62 [FALSE] L0001
       JIN             G77,G6f [FALSE] L0001
       CALL            R0431 (S201) -> -(SP)
       RET_POPPED      
L0001: JZ              G77 [FALSE] L0002
       PRINT_RET       "Dental hygiene is highly recommended, but I'm not sure
what you want to brush them with."
L0002: PRINT           "A nice idea, but with a "
       PRINT_OBJ       G77
       PRINT_RET       "?"

Routine R0261, 0 locals ()

       JE              G00,#dc [FALSE] L0001
       JE              G78,#3c [FALSE] RFALSE
       PRINT_RET       "The west wall is solid granite here."
L0001: JE              G00,#be [FALSE] L0002
       JE              G78,#3c [FALSE] RFALSE
       PRINT_RET       "The east wall is solid granite here."
L0002: JE              G00,#0f [FALSE] L0004
       JE              G78,#53,#3c [FALSE] L0003
       PRINT_RET       "It only SAYS "Granite Wall"."
L0003: PRINT_RET       "The wall isn't granite."
L0004: PRINT_RET       "There is no granite wall here."

Routine R0262, 0 locals ()

       JE              G78,#5d,#3c [FALSE] L0001
       PRINT_RET       "The songbird is not here but is probably nearby."
L0001: JE              G78,#4d [FALSE] L0002
       PRINT_RET       "You can't hear the songbird now."
L0002: JE              G78,#3d [FALSE] L0003
       PRINT_RET       "It can't be followed."
L0003: PRINT_RET       "You can't see any songbird here."

Routine R0263, 0 locals ()

       JE              G00,#cb,#c1,#c9 [FALSE] L0002
       JE              G78,#3c [FALSE] L0001
       PRINT_RET       "Why not find your brains?"
L0001: JE              G78,#8b [FALSE] RFALSE
       CALL            R0245 (G88) -> -(SP)
       RTRUE           
L0002: JE              G00,#4f,#b4 [TRUE] L0005
       JE              G00,#51,#50 [TRUE] L0005
       JE              G78,#3c [FALSE] L0004
       JE              G00,#4a [FALSE] L0003
       PRINT_RET       "It seems to be to the west."
L0003: PRINT_RET       "It was here just a minute ago...."
L0004: PRINT_RET       "You're not at the house."
L0005: JE              G78,#3c [FALSE] L0006
       PRINT_RET       "It's right here! Are you blind or something?"
L0006: JE              G78,#8b [FALSE] L0007
       CALL            R0245 (G8a) -> -(SP)
       RTRUE           
L0007: JE              G78,#38 [FALSE] L0008
       PRINT_RET       "The house is a beautiful colonial house which is
painted white. It is clear that the owners must have been extremely wealthy."
L0008: JE              G78,#2b,#22 [FALSE] L0011
       JE              G00,#4f [FALSE] L0010
       TEST_ATTR       "kitchen window",#0b [FALSE] L0009
       CALL            R0244 (#cb) -> -(SP)
       RET_POPPED      
L0009: PRINT           "The window is closed."
       NEW_LINE        
       CALL            R0255 (#eb) -> -(SP)
       RET_POPPED      
L0010: PRINT_RET       "I can't see how to get in from here."
L0011: JE              G78,#1c [FALSE] RFALSE
       PRINT_RET       "You must be joking."

Routine R0264, 0 locals ()

       JE              G78,#8b [FALSE] L0001
       CALL            R0245 (G89) -> -(SP)
       RET_POPPED      
L0001: JE              G78,#2d [FALSE] L0002
       PRINT_RET       "You will have to specify a direction."
L0002: JE              G78,#3c [FALSE] L0003
       PRINT_RET       "You cannot see the forest for the trees."
L0003: JE              G78,#4d [FALSE] RFALSE
       PRINT_RET       "The pines and the hemlocks seem to be murmuring."

Routine R0265, 0 locals ()

       JE              G78,#20,#1f,#1e [FALSE] RFALSE
       PRINT_RET       "Don't you believe me? The mountains are impassable!"

Routine R0266, 3 locals (0000, 0000, 0000)

       JE              G78,#40 [TRUE] RFALSE
       JE              G78,#22 [FALSE] L0001
       CALL            R0004 (G37) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           
L0001: JE              G78,#3b [FALSE] L0002
       STORE           L01,G77
       STORE           G78,#12
       STORE           G77,G76
       STORE           G76,L01
       STORE           L02,#00
       JUMP            L0005
L0002: JE              G76,#ee [TRUE] L0003
       JE              G76,#ed [FALSE] L0004
L0003: STORE           L01,G76
       STORE           L02,#00
       JUMP            L0005
L0004: STORE           L01,G77
       JZ              L01 [TRUE] L0005
       STORE           L02,#01
L0005: JE              L01,#ee [FALSE] L0006
       STORE           L01,#ed
       JE              G78,#12,#5d [FALSE] L0006
       CALL            R0116 (L01) -> -(SP)
L0006: JZ              L02 [TRUE] L0007
       STORE           G77,L01
       JUMP            L0008
L0007: STORE           G76,L01
L0008: GET_PARENT      G6f -> L00
       TEST_ATTR       L00,#1b [TRUE] L0009
       STORE           L00,#00
L0009: JE              G78,#12,#5d [FALSE] L0017
       JZ              L02 [FALSE] L0017
       JZ              L00 [TRUE] L0011
       JE              L00,G77 [TRUE] L0010
       JZ              G77 [FALSE] L0011
       JIN             L01,L00 [TRUE] L0011
L0010: PRINT           "There is now a puddle in the bottom of the "
       PRINT_OBJ       L00
       PRINT           "."
       NEW_LINE        
       CALL            R0116 (G76) -> -(SP)
       INSERT_OBJ      G76,L00
       RTRUE           
L0011: JZ              G77 [TRUE] L0012
       JE              G77,#ec [TRUE] L0012
       PRINT           "The water leaks out of the "
       PRINT_OBJ       G77
       PRINT           " and evaporates immediately."
       NEW_LINE        
       CALL            R0116 (L01) -> -(SP)
       RET_POPPED      
L0012: JIN             "glass bottle",G6f [FALSE] L0015
       TEST_ATTR       "glass bottle",#0b [TRUE] L0013
       PRINT           "The bottle is closed."
       NEW_LINE        
       CALL            R0255 (#ec) -> -(SP)
       RET_POPPED      
L0013: GET_CHILD       "glass bottle" -> -(SP) [TRUE] L0014
       INSERT_OBJ      "quantity of water","glass bottle"
       PRINT_RET       "The bottle is now full of water."
L0014: PRINT_RET       "The water slips through your fingers."
L0015: JIN             G76,"glass bottle" [FALSE] L0016
       JE              G78,#5d [FALSE] L0016
       JZ              G77 [FALSE] L0016
       PRINT_RET       "It's in the bottle. Perhaps you should take that
instead."
L0016: PRINT_RET       "The water slips through your fingers."
L0017: JZ              L02 [TRUE] L0018
       PRINT_RET       "Nice try."
L0018: JE              G78,#3f,#31 [FALSE] L0020
       CALL            R0116 (#ed) -> -(SP)
       JZ              L00 [TRUE] L0019
       PRINT           "There is now a puddle in the bottom of the "
       PRINT_OBJ       L00
       PRINT           "."
       NEW_LINE        
       INSERT_OBJ      "quantity of water",L00
       RTRUE           
L0019: PRINT           "The water spills to the floor and evaporates
immediately."
       NEW_LINE        
       CALL            R0116 (#ed) -> -(SP)
       RET_POPPED      
L0020: JE              G78,#7f [FALSE] RFALSE
       PRINT           "The water splashes on the walls and evaporates
immediately."
       NEW_LINE        
       CALL            R0116 (#ed) -> -(SP)
       RET_POPPED      

Routine R0267, 0 locals ()

       JE              G78,#23,#2b [FALSE] L0001
       STORE           G33,#01
       CALL            R0258 (#eb,S202,S203) -> -(SP)
       RET_POPPED      
L0001: JE              G78,#38 [FALSE] L0002
       JZ              G33 [FALSE] L0002
       PRINT_RET       "The window is slightly ajar, but not enough to allow
entry."
L0002: JE              G78,#22,#19,#89 [FALSE] L0004
       JE              G00,#cb [FALSE] L0003
       CALL            R0247 (#1e) -> -(SP)
       RTRUE           
L0003: CALL            R0247 (#1d) -> -(SP)
       RTRUE           
L0004: JE              G78,#39 [FALSE] RFALSE
       PRINT           "You can see "
       JE              G00,#cb [FALSE] L0005
       PRINT_RET       "a clear area leading towards a forest."
L0005: PRINT_RET       "what appears to be a kitchen."

Routine R0268, 0 locals ()

       JE              G78,#6f [FALSE] L0001
       PRINT           "The spirits jeer loudly and ignore you."
       NEW_LINE        
       STORE           G6c,#00
       RET             G6c
L0001: JE              G78,#3a [FALSE] L0002
       PRINT_RET       "Only the ceremony itself has any effect."
L0002: JE              G78,#2a,#13 [FALSE] L0003
       JE              G76,#e9 [FALSE] L0003
       PRINT_RET       "How can you attack a spirit with material objects?"
L0003: PRINT_RET       "You seem unable to interact with these spirits."

Routine R0269, 0 locals ()

       JE              G78,#69 [FALSE] L0002
       JZ              G32 [TRUE] L0001
       CALL            R0004 (G34) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           
L0001: INSERT_OBJ      "basket","Shaft Room"
       INSERT_OBJ      "basket","Drafty Room"
       STORE           G32,#01
       CALL            R0255 (#e3) -> -(SP)
       PRINT_RET       "The basket is raised to the top of the shaft."
L0002: JE              G78,#54 [FALSE] L0004
       JZ              G32 [FALSE] L0003
       CALL            R0004 (G34) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           
L0003: INSERT_OBJ      "basket","Drafty Room"
       INSERT_OBJ      "basket","Shaft Room"
       CALL            R0255 (#e5) -> -(SP)
       PRINT           "The basket is lowered to the bottom of the shaft."
       NEW_LINE        
       STORE           G32,#00
       JZ              G42 [TRUE] RTRUE
       CALL            R0063 (G00) -> G42
       JZ              G42 [FALSE] RTRUE
       PRINT           "It is now pitch black."
       NEW_LINE        
       RTRUE           
L0004: JE              G76,#e5 [TRUE] L0005
       JE              G77,#e5 [FALSE] L0006
L0005: PRINT_RET       "The basket is at the other end of the chain."
L0006: JE              G78,#5d [FALSE] RFALSE
       JE              G76,#e3,#e5 [FALSE] RFALSE
       PRINT_RET       "The cage is securely fastened to the iron chain."

Routine R0270, 0 locals ()

       JE              G78,#6f [FALSE] L0001
       CALL            R0272 (#06) -> -(SP)
       STORE           G6c,#00
       RET             G6c
L0001: JE              G78,#2a,#13,#5d [FALSE] RFALSE
       GET_PARENT      "clove of garlic" -> -(SP)
       JE              (SP)+,G6f,G00 [FALSE] L0002
       PRINT_RET       "You can't reach him; he's on the ceiling."
L0002: CALL            R0271 -> -(SP)
       RET_POPPED      

Routine R0271, 0 locals ()

       CALL            R0272 (#04) -> -(SP)
       NEW_LINE        
       PRINT           "The bat grabs you by the scruff of your neck and lifts
you away...."
       NEW_LINE        
       NEW_LINE        
       CALL            R0004 (G31) -> -(SP)
       CALL            R0244 ((SP)+,#00) -> -(SP)
       CALL            R0226 -> -(SP)
       RTRUE           

Routine R0272, 1 local (0000)

L0001: DEC_CHK         L00,#01 [FALSE] L0002
       JUMP            L0003
L0002: PRINT           "    Fweep!"
       NEW_LINE        
       JUMP            L0001
L0003: NEW_LINE        
       RTRUE           

Routine R0273, 0 locals ()

       JE              G78,#6d [FALSE] RFALSE
       JE              G00,#5a7f [FALSE] L0001
       JZ              G91 [TRUE] RFALSE
L0001: PRINT_RET       "Ding, dong."

Routine R0274, 0 locals ()

       JE              G78,#5d [FALSE] L0001
       PRINT_RET       "The bell is very hot and cannot be taken."
L0001: JE              G78,#6e [TRUE] L0002
       JE              G78,#6d [FALSE] L0005
       JZ              G77 [TRUE] L0005
L0002: TEST_ATTR       G77,#1a [FALSE] L0003
       PRINT           "The "
       PRINT_OBJ       G77
       PRINT           " burns and is consumed."
       NEW_LINE        
       CALL            R0116 (G77) -> -(SP)
       RET_POPPED      
L0003: JE              G77,#01 [FALSE] L0004
       PRINT_RET       "The bell is too hot to touch."
L0004: PRINT_RET       "The heat from the bell is too intense."
L0005: JE              G78,#61 [FALSE] L0006
       CALL            R0116 (G76) -> -(SP)
       PRINT           "The water cools the bell and is evaporated."
       NEW_LINE        
       CALL            R0022 (#5c72,#00) -> -(SP)
       CALL            R0313 -> -(SP)
       RET_POPPED      
L0006: JE              G78,#6d [FALSE] RFALSE
       PRINT_RET       "The bell is too hot to reach."

Routine R0275, 0 locals ()

       JE              G78,#2b [FALSE] L0001
       PRINT_RET       "The windows are boarded and can't be opened."
L0001: JE              G78,#2a [FALSE] RFALSE
       PRINT_RET       "You can't break the windows open."

Routine R0276, 0 locals ()

       JE              G78,#5d [FALSE] RFALSE
       PRINT_RET       "The nails, deeply imbedded in the door, cannot be
removed."

Routine R0277, 0 locals ()

       JE              G78,#22 [FALSE] RFALSE
       PRINT_RET       "You can't fit through the crack."

Routine R0278, 1 local (0000)

       JE              L00,#03 [FALSE] L0002
       PRINT           "You are in the kitchen of the white house. A table
seems to have been used recently for the preparation of food. A passage leads
to the west and a dark staircase can be seen leading upward. A dark chimney
leads down and to the east is a small window which is "
       TEST_ATTR       "kitchen window",#0b [FALSE] L0001
       PRINT_RET       "open."
L0001: PRINT_RET       "slightly ajar."
L0002: JE              L00,#01 [FALSE] RFALSE
       JE              G78,#1e [FALSE] L0003
       JE              G76,#49 [FALSE] L0003
       CALL            R0247 (#17) -> -(SP)
       RET_POPPED      
L0003: JE              G78,#1e [FALSE] RFALSE
       JE              G76,#49 [FALSE] RFALSE
       PRINT_RET       "There are no stairs leading down."

Routine R0279, 1 local (0000)

       JE              L00,#01 [FALSE] RFALSE
       JE              G78,#36 [TRUE] L0002
       JE              G78,#89 [FALSE] L0001
       JE              G76,#1d,#15 [TRUE] L0002
L0001: JE              G78,#22 [FALSE] RFALSE
       JE              G76,#b1 [FALSE] RFALSE
L0002: PRINT           "Inside the Barrow
As you enter the barrow, the door closes inexorably behind you. Around you it
is dark, but ahead is an enormous cavern, brightly lit. Through its center runs
a wide stream. Spanning the stream is a small wooden footbridge, and beyond a
path leads into a dark tunnel. Above the bridge, floating in the air, is a
large sign. It reads:  All ye who stand before this bridge have completed a
great and perilous adventure which has tested your wit and courage. You have
mastered"
       LOADB           #00,#01 -> -(SP)
       AND             (SP)+,#08 -> -(SP)
       JZ              (SP)+ [FALSE] L0003
       PRINT           " the first part of the ZORK trilogy. Those who pass
over this bridge must be prepared to undertake an even greater adventure that
will severely test your skill and bravery!

The ZORK trilogy continues with "ZORK II: The Wizard of Frobozz" and is
completed in "ZORK III: The Dungeon Master.""
       NEW_LINE        
       JUMP            L0004
L0003: PRINT           " ZORK: The Great Underground Empire.
"
       NEW_LINE        
L0004: CALL            R0071 (#00) -> -(SP)
       RET_POPPED      

Routine R0280, 0 locals ()

       JE              G78,#23,#2b [FALSE] RFALSE
       PRINT_RET       "The door is too heavy."

Routine R0281, 0 locals ()

       JE              G78,#22 [FALSE] RFALSE
       CALL            R0247 (#1d) -> -(SP)
       RET_POPPED      

Routine R0282, 0 locals ()

       JE              G78,#5d [FALSE] RFALSE
       JE              G76,#c2 [FALSE] RFALSE
       PRINT_RET       "The trophy case is securely fastened to the wall."

Routine R0283, 3 locals (0000, 0000, 0000)

       JE              L00,#03 [FALSE] L0007
       PRINT           "You are in the living room. There is a doorway to the
east"
       JZ              G8f [TRUE] L0001
       PRINT           ". To the west is a cyclops-shaped opening in an old
wooden door, above which is some strange gothic lettering, "
       JUMP            L0002
L0001: PRINT           ", a wooden door with strange gothic lettering to the
west, which appears to be nailed shut, "
L0002: PRINT           "a trophy case, "
       STORE           L01,G30
       JZ              L01 [TRUE] L0003
       TEST_ATTR       "trap door",#0b [FALSE] L0003
       PRINT           "and a rug lying beside an open trap door."
       JUMP            L0006
L0003: JZ              L01 [TRUE] L0004
       PRINT           "and a closed trap door at your feet."
       JUMP            L0006
L0004: TEST_ATTR       "trap door",#0b [FALSE] L0005
       PRINT           "and an open trap door at your feet."
       JUMP            L0006
L0005: PRINT           "and a large oriental rug in the center of the room."
L0006: NEW_LINE        
       RTRUE           
L0007: JE              L00,#06 [FALSE] RFALSE
       JE              G78,#5d [TRUE] L0008
       JE              G78,#12 [FALSE] RFALSE
       JE              G77,#c2 [FALSE] RFALSE
L0008: JIN             G76,"trophy case" [FALSE] L0009
       CALL            R0284 (G76) -> -(SP)
L0009: CALL            R0285 -> -(SP)
       ADD             G3f,(SP)+ -> G01
       CALL            R0234 (#00) -> -(SP)
       RFALSE          

Routine R0284, 2 locals (0000, 0000)

       GET_CHILD       L00 -> L01 [TRUE] L0001
L0001: JZ              L01 [TRUE] RTRUE
       SET_ATTR        L01,#03
       GET_CHILD       L01 -> -(SP) [FALSE] L0002
       CALL            R0284 (L01) -> -(SP)
L0002: GET_SIBLING     L01 -> L01 [TRUE] L0003
L0003: JUMP            L0001

Routine R0285, 3 locals (00c2, 0000, 0000)

       GET_CHILD       L00 -> L01 [TRUE] L0001
L0001: JZ              L01 [FALSE] L0002
       RET             L02
L0002: GET_PROP        L01,#0c -> -(SP)
       ADD             L02,(SP)+ -> L02
       GET_CHILD       L01 -> -(SP) [FALSE] L0003
       CALL            R0285 (L01) -> -(SP)
L0003: GET_SIBLING     L01 -> L01 [TRUE] L0004
L0004: JUMP            L0001

Routine R0286, 0 locals ()

       JE              G78,#69 [FALSE] L0001
       CALL            R0026 (#2b,#b7) -> -(SP)
       RTRUE           
L0001: JE              G78,#23,#2b [FALSE] L0002
       JE              G00,#c1 [FALSE] L0002
       CALL            R0258 (G76,S204,S205) -> -(SP)
       RET_POPPED      
L0002: JE              G78,#51 [FALSE] L0004
       JE              G00,#c1 [FALSE] L0004
       TEST_ATTR       "trap door",#0b [FALSE] L0003
       PRINT_RET       "You see a rickety staircase descending into darkness."
L0003: PRINT_RET       "It's closed."
L0004: JE              G00,#48 [FALSE] RFALSE
       JE              G78,#85,#2b [FALSE] L0005
       TEST_ATTR       "trap door",#0b [TRUE] L0005
       PRINT_RET       "The door is locked from above."
L0005: JE              G78,#23 [FALSE] L0006
       TEST_ATTR       "trap door",#0b [TRUE] L0006
       CLEAR_ATTR      "trap door",#03
       CLEAR_ATTR      "trap door",#0b
       PRINT_RET       "The door closes and locks."
L0006: JE              G78,#23,#2b [FALSE] RFALSE
       CALL            R0004 (G34) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           

Routine R0287, 1 local (0000)

       JE              L00,#03 [FALSE] L0001
       PRINT_RET       "You are in a dark and damp cellar with a narrow
passageway leading north, and a crawlway to the south. On the west is the
bottom of a steep metal ramp which is unclimbable."
L0001: JE              L00,#02 [FALSE] RFALSE
       TEST_ATTR       "trap door",#0b [FALSE] RFALSE
       TEST_ATTR       "trap door",#03 [TRUE] RFALSE
       CLEAR_ATTR      "trap door",#0b
       SET_ATTR        "trap door",#03
       PRINT           "The trap door crashes shut, and you hear someone
barring it."
       NEW_LINE        
       NEW_LINE        
       RTRUE           

Routine R0288, 0 locals ()

       JE              G78,#38 [FALSE] RFALSE
       PRINT           "The chimney leads "
       JE              G00,#cb [FALSE] L0001
       PRINT           "down"
       JUMP            L0002
L0001: PRINT           "up"
L0002: PRINT_RET       "ward, and looks climbable."

Routine R0289, 1 local (0000)

       GET_CHILD       G6f -> L00 [TRUE] L0001
       PRINT           "Going up empty-handed is a bad idea."
       NEW_LINE        
       RFALSE          
L0001: GET_SIBLING     L00 -> L00 [FALSE] L0002
       GET_SIBLING     L00 -> -(SP) [TRUE] L0004
L0002: JIN             "brass lantern",G6f [FALSE] L0004
       TEST_ATTR       "trap door",#0b [TRUE] L0003
       CLEAR_ATTR      "trap door",#03
       RET             #cb
L0003: RET             #cb
L0004: PRINT           "You can't get up there with what you're carrying."
       NEW_LINE        
       RFALSE          

Routine R0290, 0 locals ()

       JZ              G30 [TRUE] L0002
       TEST_ATTR       "trap door",#0b [FALSE] L0001
       RET             #48
L0001: PRINT           "The trap door is closed."
       NEW_LINE        
       CALL            R0255 (#b7) -> -(SP)
       RFALSE          
L0002: PRINT           "You can't go that way."
       NEW_LINE        
       RFALSE          

Routine R0291, 0 locals ()

       JE              G78,#69 [FALSE] L0002
       PRINT           "The rug is too heavy to lift"
       JZ              G30 [TRUE] L0001
       PRINT_RET       "."
L0001: PRINT_RET       ", but in trying to take it you have noticed an
irregularity beneath it."
L0002: JE              G78,#65,#58 [FALSE] L0004
       JZ              G30 [TRUE] L0003
       PRINT_RET       "Having moved the carpet previously, you find it
impossible to move it again."
L0003: PRINT           "With a great effort, the rug is moved to one side of
the room, revealing the dusty cover of a closed trap door."
       NEW_LINE        
       CLEAR_ATTR      "trap door",#07
       CALL            R0255 (#b7) -> -(SP)
       STORE           G30,#01
       RET             G30
L0004: JE              G78,#5d [FALSE] L0005
       PRINT_RET       "The rug is extremely heavy and cannot be carried."
L0005: JE              G78,#51 [FALSE] L0006
       JZ              G30 [FALSE] L0006
       TEST_ATTR       "trap door",#0b [TRUE] L0006
       PRINT_RET       "Underneath the rug is a closed trap door. As you drop
the corner of the rug, the trap door is once again concealed from view."
L0006: JE              G78,#21 [FALSE] RFALSE
       JZ              G30 [FALSE] L0007
       TEST_ATTR       "trap door",#0b [TRUE] L0007
       PRINT_RET       "As you sit, you notice an irregularity underneath it.
Rather than be uncomfortable, you stand up again."
L0007: PRINT_RET       "I suppose you think it's a magic carpet?"

Routine R0292, 0 locals ()

       JZ              G8d [FALSE] RFALSE
       CALL            R0294 (#da,#d9) -> -(SP)
       RET_POPPED      

Routine R0293, 0 locals ()

       CALL            R0294 (#71,#72) -> -(SP)
       RET_POPPED      

Routine R0294, 2 locals (0000, 0000)

       JIN             L01,G00 [FALSE] RFALSE
       JE              G78,#5d [FALSE] RFALSE
       JIN             L00,L01 [FALSE] L0001
       PRINT           "The "
       PRINT_OBJ       L01
       PRINT_RET       " swings it out of your reach."
L0001: PRINT           "The "
       PRINT_OBJ       L00
       PRINT           " seems white-hot. You can't hold on to it."
       NEW_LINE        
       RTRUE           

Routine R0295, 1 local (0000)

       JE              G78,#6f [FALSE] L0001
       PRINT           "The troll isn't much of a conversationalist."
       NEW_LINE        
       STORE           G6c,#00
       RET             G6c
L0001: JE              L00,#01 [FALSE] L0003
       JIN             "bloody axe","troll" [TRUE] RFALSE
       JIN             "bloody axe",G00 [FALSE] L0002
       CALL            R0002 (#4b) -> -(SP)
       JZ              (SP)+ [TRUE] L0002
       SET_ATTR        "bloody axe",#0e
       CLEAR_ATTR      "bloody axe",#1d
       INSERT_OBJ      "bloody axe","troll"
       PUT_PROP        "troll",#0b,S206
       JIN             "troll",G00 [FALSE] RTRUE
       PRINT_RET       "The troll, angered and humiliated, recovers his weapon.
He appears to have an axe to grind with you."
L0002: JIN             "troll",G00 [FALSE] RFALSE
       PUT_PROP        "troll",#0b,S207
       PRINT           "The troll, disarmed, cowers in terror, pleading for his
life in the guttural tongue of the trolls."
       NEW_LINE        
       RTRUE           
L0003: JE              L00,#02 [FALSE] L0005
       JIN             "bloody axe","troll" [FALSE] L0004
       INSERT_OBJ      "bloody axe",G00
       CLEAR_ATTR      "bloody axe",#0e
       SET_ATTR        "bloody axe",#1d
L0004: STORE           G8d,#01
       RET             G8d
L0005: JE              L00,#03 [FALSE] L0007
       CLEAR_ATTR      "troll",#02
       JIN             "bloody axe","troll" [FALSE] L0006
       INSERT_OBJ      "bloody axe",G00
       CLEAR_ATTR      "bloody axe",#0e
       SET_ATTR        "bloody axe",#1d
L0006: PUT_PROP        "troll",#0b,S208
       STORE           G8d,#01
       RET             G8d
L0007: JE              L00,#04 [FALSE] L0012
       JIN             "troll",G00 [FALSE] L0008
       SET_ATTR        "troll",#02
       PRINT           "The troll stirs, quickly resuming a fighting stance."
       NEW_LINE        
L0008: JIN             "bloody axe","troll" [FALSE] L0009
       PUT_PROP        "troll",#0b,S209
       JUMP            L0011
L0009: JIN             "bloody axe","The Troll Room" [FALSE] L0010
       SET_ATTR        "bloody axe",#0e
       CLEAR_ATTR      "bloody axe",#1d
       INSERT_OBJ      "bloody axe","troll"
       PUT_PROP        "troll",#0b,S209
       JUMP            L0011
L0010: PUT_PROP        "troll",#0b,S210
L0011: STORE           G8d,#00
       RET             G8d
L0012: JE              L00,#05 [FALSE] L0013
       RANDOM          #64 -> -(SP)
       JG              #21,(SP)+ [FALSE] RFALSE
       SET_ATTR        "troll",#02
       STORE           G6c,#00
       RTRUE           
L0013: JZ              L00 [FALSE] RFALSE
       JE              G78,#38 [FALSE] L0014
       GET_PROP        "troll",#0b -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           
L0014: JE              G78,#3f,#7f [FALSE] L0015
       JZ              G76 [TRUE] L0015
       JE              G77,#d9 [TRUE] L0016
L0015: JE              G78,#2a,#58,#5d [FALSE] L0025
L0016: CALL            R0421 (#d9) -> -(SP)
       JE              G78,#3f,#7f [FALSE] L0023
       JE              G76,#da [FALSE] L0017
       JIN             "bloody axe",G6f [FALSE] L0017
       PRINT           "The troll scratches his head in confusion, then takes
the axe."
       NEW_LINE        
       SET_ATTR        "troll",#02
       INSERT_OBJ      "bloody axe","troll"
       RTRUE           
L0017: JE              G76,#d9,#da [FALSE] L0018
       PRINT           "You would have to get the "
       PRINT_OBJ       G76
       PRINT_RET       " first, and that seems unlikely."
L0018: JE              G78,#7f [FALSE] L0019
       PRINT           "The troll, who is remarkably coordinated, catches the "
       PRINT_OBJ       G76
       JUMP            L0020
L0019: PRINT           "The troll, who is not overly proud, graciously accepts
the gift"
L0020: RANDOM          #64 -> -(SP)
       JG              #14,(SP)+ [FALSE] L0021
       JE              G76,#a9,#6e,#da [FALSE] L0021
       CALL            R0116 (G76) -> -(SP)
       PRINT           " and eats it hungrily. Poor troll, he dies from an
internal hemorrhage and his carcass disappears in a sinister black fog."
       NEW_LINE        
       CALL            R0116 (#d9) -> -(SP)
       GET_PROP        "troll",#11 -> -(SP)
       CALL            (SP)+ (#02) -> -(SP)
       STORE           G8d,#01
       RET             G8d
L0021: JE              G76,#a9,#6e,#da [FALSE] L0022
       INSERT_OBJ      G76,G00
       PRINT           " and, being for the moment sated, throws it back.
Fortunately, the troll has poor control, and the "
       PRINT_OBJ       G76
       PRINT           " falls to the floor. He does not look pleased."
       NEW_LINE        
       SET_ATTR        "troll",#02
       RTRUE           
L0022: PRINT           " and not having the most discriminating tastes,
gleefully eats it."
       NEW_LINE        
       CALL            R0116 (G76) -> -(SP)
       RET_POPPED      
L0023: JE              G78,#58,#5d [FALSE] L0024
       PRINT_RET       "The troll spits in your face, grunting "Better luck
next time" in a rather barbarous accent."
L0024: JE              G78,#2a [FALSE] RFALSE
       PRINT_RET       "The troll laughs at your puny gesture."
L0025: JE              G78,#4d [FALSE] L0026
       PRINT_RET       "Every so often the troll says something, probably
uncomplimentary, in his guttural tongue."
L0026: JZ              G8d [TRUE] RFALSE
       JE              G78,#42 [FALSE] RFALSE
       PRINT_RET       "Unfortunately, the troll can't hear you."

Routine R0296, 0 locals ()

       TEST_ATTR       "grating",#0b [TRUE] RFALSE
       JZ              G2e [FALSE] RFALSE
       JE              G78,#5d,#58 [FALSE] L0001
       PRINT           "In disturbing the pile of leaves, a grating is
revealed."
       NEW_LINE        
       JUMP            L0002
L0001: PRINT           "With the leaves moved, a grating is revealed."
       NEW_LINE        
L0002: CLEAR_ATTR      "grating",#07
       STORE           G2e,#01
       RFALSE          

Routine R0297, 0 locals ()

       JE              G78,#25 [FALSE] L0001
       PRINT_RET       "There are 69,105 leaves here."
L0001: JE              G78,#1c [FALSE] L0003
       CALL            R0296 -> -(SP)
       CALL            R0116 (G76) -> -(SP)
       JIN             G76,G00 [FALSE] L0002
       PRINT_RET       "The leaves burn."
L0002: CALL            R0431 (S211) -> -(SP)
       RET_POPPED      
L0003: JE              G78,#27 [FALSE] L0004
       PRINT           "You rustle the leaves around, making quite a mess."
       NEW_LINE        
       CALL            R0296 -> -(SP)
       RTRUE           
L0004: JE              G78,#5d,#58 [FALSE] L0006
       JE              G78,#58 [FALSE] L0005
       PRINT           "Done."
       NEW_LINE        
L0005: JZ              G2e [FALSE] RFALSE
       CALL            R0296 -> -(SP)
       JE              G78,#5d [FALSE] RTRUE
       RFALSE          
L0006: JE              G78,#51 [FALSE] RFALSE
       JZ              G2e [FALSE] RFALSE
       PRINT_RET       "Underneath the pile of leaves is a grating. As you
release the leaves, the grating is once again concealed from view."

Routine R0298, 1 local (0000)

       JE              L00,#02 [FALSE] L0001
       JZ              G2e [FALSE] RFALSE
       SET_ATTR        "grating",#07
       RTRUE           
L0001: JE              L00,#03 [FALSE] RFALSE
       PRINT           "You are in a clearing, with a forest surrounding you on
all sides. A path leads south."
       TEST_ATTR       "grating",#0b [FALSE] L0002
       NEW_LINE        
       PRINT           "There is an open grating, descending into darkness."
       JUMP            L0003
L0002: JZ              G2e [TRUE] L0003
       NEW_LINE        
       PRINT           "There is a grating securely fastened into the ground."
L0003: NEW_LINE        
       RTRUE           

Routine R0299, 1 local (0000)

       JE              L00,#02 [FALSE] L0001
       CLEAR_ATTR      "grating",#07
       RTRUE           
L0001: JE              L00,#03 [FALSE] RFALSE
       PRINT           "You are in a small room near the maze. There are twisty
passages in the immediate vicinity."
       NEW_LINE        
       TEST_ATTR       "grating",#0b [FALSE] L0002
       PRINT           "Above you is an open grating with sunlight pouring in."
       JUMP            L0004
L0002: JZ              G2d [TRUE] L0003
       PRINT           "Above you is a grating."
       JUMP            L0004
L0003: PRINT           "Above you is a grating locked with a
skull-and-crossbones lock."
L0004: NEW_LINE        
       RTRUE           

Routine R0300, 0 locals ()

       JE              G78,#2b [FALSE] L0001
       JE              G77,#7a [FALSE] L0001
       CALL            R0026 (#85,#ae,#7a) -> -(SP)
       RTRUE           
L0001: JE              G78,#4e [FALSE] L0003
       JE              G00,#39 [FALSE] L0002
       STORE           G2d,#00
       PRINT_RET       "The grate is locked."
L0002: JE              G00,#8f [FALSE] RFALSE
       PRINT_RET       "You can't lock it from this side."
L0003: JE              G78,#85 [FALSE] L0006
       JE              G76,#ae [FALSE] L0006
       JE              G00,#39 [FALSE] L0004
       JE              G77,#7a [FALSE] L0004
       STORE           G2d,#01
       PRINT_RET       "The grate is unlocked."
L0004: JE              G00,#8f [FALSE] L0005
       JE              G77,#7a [FALSE] L0005
       PRINT_RET       "You can't reach the lock from here."
L0005: PRINT           "Can you unlock a grating with a "
       PRINT_OBJ       G77
       PRINT_RET       "?"
L0006: JE              G78,#5c [FALSE] L0007
       PRINT_RET       "You can't pick the lock."
L0007: JE              G78,#23,#2b [FALSE] L0013
       JZ              G2d [TRUE] L0012
       JE              G00,#4a [FALSE] L0008
       PUSH            S212
       JUMP            L0009
L0008: PUSH            S213
L0009: CALL            R0258 (#ae,(SP)+,S090) -> -(SP)
       TEST_ATTR       "grating",#0b [FALSE] L0011
       JE              G00,#4a [TRUE] L0010
       JZ              G2e [FALSE] L0010
       PRINT           "A pile of leaves falls onto your head and to the
ground."
       NEW_LINE        
       STORE           G2e,#01
       INSERT_OBJ      "pile of leaves",G00
L0010: SET_ATTR        "Grating Room",#14
       RTRUE           
L0011: CLEAR_ATTR      "Grating Room",#14
       RTRUE           
L0012: PRINT_RET       "The grating is locked."
L0013: JE              G78,#12 [FALSE] RFALSE
       JE              G77,#ae [FALSE] RFALSE
       GET_PROP        G76,#0f -> -(SP)
       JG              (SP)+,#14 [FALSE] L0014
       PRINT_RET       "It won't fit through the grating."
L0014: INSERT_OBJ      G76,"Grating Room"
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " goes through the grating into the darkness below."

Routine R0301, 0 locals ()

       PRINT           "You won't be able to get back up to the tunnel you are
going through when it gets to the next room."
       NEW_LINE        
       NEW_LINE        
       JE              G00,#45 [FALSE] L0001
       RET             #43
L0001: JE              G00,#3f [FALSE] L0002
       RET             #42
L0002: JE              G00,#3c [FALSE] L0003
       RET             #3a
L0003: JE              G00,#38 [FALSE] RFALSE
       RET             #a7

Routine R0302, 0 locals ()

       JE              G78,#5d [FALSE] L0001
       JIN             "sword",G6f [FALSE] RFALSE
       PRINT           "As you touch the rusty knife, your sword gives a single
pulse of blinding blue light."
       NEW_LINE        
       RFALSE          
L0001: JE              G77,#80 [FALSE] L0002
       JE              G78,#13 [TRUE] L0003
L0002: JE              G78,#7e [FALSE] RFALSE
       JE              G76,#80 [FALSE] RFALSE
       JZ              G77 [TRUE] RFALSE
L0003: CALL            R0116 (#80) -> -(SP)
       CALL            R0431 (S214) -> -(SP)
       RET_POPPED      

Routine R0303, 0 locals ()

       JE              G78,#5d [FALSE] RFALSE
       CLEAR_ATTR      "table",#0e
       RFALSE          

Routine R0304, 0 locals ()

       JE              G78,#58,#6e,#5d [TRUE] L0001
       JE              G78,#54,#69,#65 [TRUE] L0001
       JE              G78,#48,#46,#13 [FALSE] RFALSE
L0001: PRINT           "A ghost appears in the room and is appalled at your
desecration of the remains of a fellow adventurer. He casts a curse on your
valuables and banishes them to the Land of the Living Dead. The ghost leaves,
muttering obscenities."
       NEW_LINE        
       CALL            R0428 (G00,#e6,#64) -> -(SP)
       CALL            R0428 (#04,#e6) -> -(SP)
       RTRUE           

Routine R0305, 0 locals ()

       JE              G78,#38 [FALSE] L0001
       PRINT_RET       "The torch is burning."
L0001: JE              G78,#61 [FALSE] L0002
       JE              G77,#68 [FALSE] L0002
       PRINT_RET       "The water evaporates before it gets close."
L0002: JE              G78,#16 [FALSE] RFALSE
       TEST_ATTR       G76,#14 [FALSE] RFALSE
       PRINT_RET       "You nearly burn your hand trying to extinguish the
flame."

Routine R0306, 1 local (0000)

       JE              L00,#03 [FALSE] RFALSE
       PRINT           "You are in a large square room with tall ceilings. On
the south wall is an enormous mirror which fills the entire wall. There are
exits on the other three sides of the room."
       NEW_LINE        
       JZ              G2c [TRUE] RFALSE
       PRINT_RET       "Unfortunately, the mirror has been destroyed by your
recklessness."

Routine R0307, 4 locals (0098, 0000, 0000, 0000)

       JZ              G2c [FALSE] L0011
       JE              G78,#6e [FALSE] L0011
       JZ              G77 [TRUE] L0001
       JE              G77,#01 [TRUE] L0001
       PRINT           "You feel a faint tingling transmitted through the "
       PRINT_OBJ       G77
       PRINT_RET       "."
L0001: JE              G00,L00 [FALSE] L0002
       STORE           L00,#96
L0002: GET_CHILD       G00 -> L01 [TRUE] L0003
L0003: GET_CHILD       L00 -> L02 [TRUE] L0004
L0004: JZ              L01 [FALSE] L0005
       JUMP            L0007
L0005: GET_SIBLING     L01 -> L03 [TRUE] L0006
L0006: INSERT_OBJ      L01,L00
       STORE           L01,L03
       JUMP            L0004
L0007: JZ              L02 [FALSE] L0008
       JUMP            L0010
L0008: GET_SIBLING     L02 -> L03 [TRUE] L0009
L0009: INSERT_OBJ      L02,G00
       STORE           L02,L03
       JUMP            L0007
L0010: CALL            R0244 (L00,#00) -> -(SP)
       PRINT_RET       "There is a rumble from deep within the earth and the
room shakes."
L0011: JE              G78,#38,#39 [FALSE] L0014
       JZ              G2c [TRUE] L0012
       PRINT           "The mirror is broken into many pieces."
       JUMP            L0013
L0012: PRINT           "There is an ugly person staring back at you."
L0013: NEW_LINE        
       RTRUE           
L0014: JE              G78,#5d [FALSE] L0015
       PRINT_RET       "The mirror is many times your size. Give up."
L0015: JE              G78,#13,#7f,#2a [FALSE] RFALSE
       JZ              G2c [TRUE] L0016
       PRINT_RET       "Haven't you done enough damage already?"
L0016: STORE           G2c,#01
       STORE           G3c,#00
       PRINT_RET       "You have broken the mirror. I hope you have a seven
years' supply of good luck handy."

Routine R0308, 1 local (0000)

       JE              L00,#03 [FALSE] RFALSE
       PRINT           "This is a large room with a prominent doorway leading
to a down staircase. Above you is a large dome. Up around the edge of the dome
(20 feet up) is a wooden railing. In the center of the room sits a white marble
pedestal."
       NEW_LINE        
       JZ              G93 [TRUE] RFALSE
       PRINT_RET       "A piece of rope descends from the railing above, ending
some five feet above your head."

Routine R0309, 1 local (0000)

       JE              L00,#03 [FALSE] L0001
       PRINT           "You are at the periphery of a large dome, which forms
the ceiling of another room below. Protecting you from a precipitous drop is a
wooden railing which circles the dome."
       NEW_LINE        
       JZ              G93 [TRUE] RFALSE
       PRINT_RET       "Hanging down from the railing is a rope which ends
about ten feet from the floor below."
L0001: JE              L00,#02 [FALSE] RFALSE
       JZ              G3e [TRUE] L0002
       PRINT           "As you enter the dome you feel a strong pull as if from
a wind drawing you over the railing and down."
       NEW_LINE        
       INSERT_OBJ      G6f,"Torch Room"
       STORE           G00,#69
       RTRUE           
L0002: JE              G78,#45 [FALSE] RFALSE
       CALL            R0431 (S215) -> -(SP)
       RET_POPPED      

Routine R0310, 1 local (0000)

       JE              L00,#03 [FALSE] L0001
       PRINT           "You are outside a large gateway, on which is inscribed

  Abandon every hope all ye who enter here!

The gate is open; through it you can see a desolation, with a pile of mangled
bodies in one corner. Thousands of voices, lamenting some hideous fate, can be
heard."
       NEW_LINE        
       JZ              G91 [FALSE] RFALSE
       JZ              G3e [FALSE] RFALSE
       PRINT_RET       "The way through the gate is barred by evil spirits, who
jeer at your attempts to pass."
L0001: JE              L00,#01 [FALSE] L0006
       JE              G78,#3a [FALSE] L0003
       JZ              G91 [FALSE] RFALSE
       JIN             "brass bell",G6f [FALSE] L0002
       JIN             "black book",G6f [FALSE] L0002
       JIN             "pair of candles",G6f [FALSE] L0002
       PRINT_RET       "You must perform the ceremony."
L0002: PRINT_RET       "You aren't equipped for an exorcism."
L0003: JZ              G91 [FALSE] L0005
       JE              G78,#6d [FALSE] L0005
       JE              G76,#dd [FALSE] L0005
       STORE           G2a,#01
       CALL            R0116 (#dd) -> -(SP)
       CALL            R0255 (#db) -> -(SP)
       INSERT_OBJ      "red hot brass bell",G00
       PRINT           "The bell suddenly becomes red hot and falls to the
ground. The wraiths, as if paralyzed, stop their jeering and slowly turn to
face you. On their ashen faces, the expression of a long-forgotten terror takes
shape."
       NEW_LINE        
       JIN             "pair of candles",G6f [FALSE] L0004
       PRINT           "In your confusion, the candles drop to the ground (and
they are out)."
       NEW_LINE        
       INSERT_OBJ      "pair of candles",G00
       CLEAR_ATTR      "pair of candles",#14
       CALL            R0023 (#6f6a) -> -(SP)
       STOREW          (SP)+,#00,#00
L0004: CALL            R0022 (#5c3e,#06) -> -(SP)
       STOREW          (SP)+,#00,#01
       CALL            R0022 (#5c72,#14) -> -(SP)
       STOREW          (SP)+,#00,#01
       RTRUE           
L0005: JZ              G29 [TRUE] RFALSE
       JE              G78,#53 [FALSE] RFALSE
       JE              G76,#d3 [FALSE] RFALSE
       JZ              G91 [FALSE] RFALSE
       PRINT           "Each word of the prayer reverberates through the hall
in a deafening confusion. As the last word fades, a voice, loud and commanding,
speaks: "Begone, fiends!" A heart-stopping scream fills the cavern, and the
spirits, sensing a greater power, flee through the walls."
       NEW_LINE        
       CALL            R0116 (#e9) -> -(SP)
       STORE           G91,#01
       CALL            R0023 (#5c6d) -> -(SP)
       STOREW          (SP)+,#00,#00
       RTRUE           
L0006: JE              L00,#06 [FALSE] RFALSE
       JZ              G2a [TRUE] RFALSE
       JIN             "pair of candles",G6f [FALSE] RFALSE
       TEST_ATTR       "pair of candles",#14 [FALSE] RFALSE
       JZ              G29 [FALSE] RFALSE
       STORE           G29,#01
       PRINT           "The flames flicker wildly and appear to dance. The
earth beneath your feet trembles, and your legs nearly buckle beneath you. The
spirits cower at your unearthly power."
       NEW_LINE        
       CALL            R0023 (#5c3e) -> -(SP)
       STOREW          (SP)+,#00,#00
       CALL            R0022 (#5c6d,#03) -> -(SP)
       STOREW          (SP)+,#00,#01
       RTRUE           

Routine R0311, 0 locals ()

       JZ              G29 [FALSE] L0001
       JE              G00,#e8 [FALSE] L0001
       PRINT           "The tension of this ceremony is broken, and the
wraiths, amused but shaken at your clumsy attempt, resume their hideous
jeering."
       NEW_LINE        
L0001: STORE           G2a,#00
       RET             G2a

Routine R0312, 0 locals ()

       STORE           G29,#00
       CALL            R0311 -> -(SP)
       RET_POPPED      

Routine R0313, 0 locals ()

       CALL            R0116 (#db) -> -(SP)
       INSERT_OBJ      "brass bell","Entrance to Hades"
       JE              G00,#e8 [FALSE] RFALSE
       PRINT_RET       "The bell appears to have cooled down."

Routine R0314, 1 local (0000)

       JE              L00,#03 [FALSE] RFALSE
       PRINT           "You are standing on the top of the Flood Control Dam
#3, which was quite a tourist attraction in times far distant. There are paths
to the north, south, and west, and a scramble down."
       NEW_LINE        
       JZ              G90 [TRUE] L0001
       JZ              G27 [TRUE] L0001
       PRINT           "The water level behind the dam is low: The sluice gates
have been opened. Water rushes through the dam and downstream."
       NEW_LINE        
       JUMP            L0004
L0001: JZ              G27 [TRUE] L0002
       PRINT           "The sluice gates are open, and water rushes through the
dam. The water level behind the dam is still high."
       NEW_LINE        
       JUMP            L0004
L0002: JZ              G90 [TRUE] L0003
       PRINT           "The sluice gates are closed. The water level in the
reservoir is quite low, but the level is rising quickly."
       NEW_LINE        
       JUMP            L0004
L0003: PRINT           "The sluice gates on the dam are closed. Behind the dam,
there can be seen a wide reservoir. Water is pouring over the top of the now
abandoned dam."
       NEW_LINE        
L0004: PRINT           "There is a control panel here, on which a large metal
bolt is mounted. Directly above the bolt is a small green plastic bubble"
       JZ              G28 [TRUE] L0005
       PRINT           " which is glowing serenely"
L0005: PRINT_RET       "."

Routine R0315, 0 locals ()

       JE              G78,#59 [FALSE] L0005
       JE              G77,#5b [FALSE] L0003
       JZ              G28 [TRUE] L0002
       CLEAR_ATTR      "Reservoir South",#03
       JZ              G27 [TRUE] L0001
       STORE           G27,#00
       CLEAR_ATTR      "Loud Room",#03
       PRINT           "The sluice gates close and water starts to collect
behind the dam."
       NEW_LINE        
       CALL            R0022 (#5e14,#08) -> -(SP)
       STOREW          (SP)+,#00,#01
       CALL            R0022 (#5e94,#00) -> -(SP)
       RTRUE           
L0001: STORE           G27,#01
       PRINT           "The sluice gates open and water pours through the dam."
       NEW_LINE        
       CALL            R0022 (#5e94,#08) -> -(SP)
       STOREW          (SP)+,#00,#01
       CALL            R0022 (#5e14,#00) -> -(SP)
       RTRUE           
L0002: PRINT_RET       "The bolt won't turn with your best effort."
L0003: JZ              G77 [TRUE] L0004
       PRINT           "The bolt won't turn using the "
       PRINT_OBJ       G77
       PRINT_RET       "."
L0004: PRINT_RET       "You can't with your bare hands."
L0005: JE              G78,#5d [FALSE] L0006
       CALL            R0317 -> -(SP)
       RET_POPPED      
L0006: JE              G78,#55 [FALSE] RFALSE
       PRINT_RET       "Hmm. It appears the tube contained glue, not oil.
Turning the bolt won't get any easier...."

Routine R0316, 0 locals ()

       JE              G78,#5d [FALSE] RFALSE
       CALL            R0317 -> -(SP)
       RET_POPPED      

Routine R0317, 0 locals ()

       PRINT_RET       "It is an integral part of the control panel."

Routine R0318, 0 locals ()

       SET_ATTR        "Reservoir",#04
       CLEAR_ATTR      "Reservoir",#06
       CLEAR_ATTR      "Deep Canyon",#03
       CLEAR_ATTR      "Loud Room",#03
       JIN             "trunk of jewels","Reservoir" [FALSE] L0001
       SET_ATTR        "trunk of jewels",#07
L0001: STORE           G90,#00
       JE              G00,#64 [FALSE] L0003
       GET_PARENT      G6f -> -(SP)
       TEST_ATTR       (SP)+,#1b [FALSE] L0002
       PRINT_RET       "The boat lifts gently out of the mud and is now
floating on the reservoir."
L0002: CALL            R0431 (S216) -> -(SP)
       RTRUE           
L0003: JE              G00,#28 [FALSE] L0004
       PRINT_RET       "A sound, like that of flowing water, starts to come
from below."
L0004: JE              G00,#8a [FALSE] L0005
       PRINT           "All of a sudden, an alarmingly loud roaring sound fills
the room. Filled with fear, you scramble away."
       NEW_LINE        
       CALL            R0004 (G26) -> -(SP)
       CALL            R0244 ((SP)+) -> -(SP)
       RTRUE           
L0005: JE              G00,#ac,#32 [FALSE] RTRUE
       PRINT_RET       "You notice that the water level has risen to the point
that it is impossible to cross."

Routine R0319, 0 locals ()

       SET_ATTR        "Reservoir",#06
       CLEAR_ATTR      "Reservoir",#04
       CLEAR_ATTR      "Deep Canyon",#03
       CLEAR_ATTR      "Loud Room",#03
       CLEAR_ATTR      "trunk of jewels",#07
       STORE           G90,#01
       JE              G00,#64 [FALSE] L0001
       GET_PARENT      G6f -> -(SP)
       TEST_ATTR       (SP)+,#1b [FALSE] L0001
       PRINT_RET       "The water level has dropped to the point at which the
boat can no longer stay afloat. It sinks into the mud."
L0001: JE              G00,#28 [FALSE] L0002
       PRINT_RET       "The roar of rushing water is quieter now."
L0002: JE              G00,#ac,#32 [FALSE] RTRUE
       PRINT_RET       "The water level is now quite low here and you could
easily cross over to the other side."

Routine R0320, 0 locals ()

       JE              G78,#53 [FALSE] L0001
       PRINT_RET       "They're greek to you."
L0001: JE              G78,#65 [FALSE] RFALSE
       JE              G76,#c3 [FALSE] L0003
       JZ              G24 [FALSE] L0002
       CLEAR_ATTR      "leak",#07
       PRINT           "There is a rumbling sound and a stream of water appears
to burst from the east wall of the room (apparently, a leak has occurred in a
pipe)."
       NEW_LINE        
       STORE           G24,#01
       CALL            R0022 (#5f89,#ffff) -> -(SP)
       STOREW          (SP)+,#00,#01
       RTRUE           
L0002: PRINT_RET       "The blue button appears to be jammed."
L0003: JE              G76,#c4 [FALSE] L0005
       PRINT           "The lights within the room "
       TEST_ATTR       G00,#14 [FALSE] L0004
       CLEAR_ATTR      G00,#14
       PRINT_RET       "shut off."
L0004: SET_ATTR        G00,#14
       PRINT_RET       "come on."
L0005: JE              G76,#c5 [FALSE] L0006
       CLEAR_ATTR      "Dam",#03
       STORE           G28,#00
       PRINT_RET       "Click."
L0006: JE              G76,#c6 [FALSE] RFALSE
       CLEAR_ATTR      "Dam",#03
       STORE           G28,#01
       PRINT_RET       "Click."

Routine R0321, 0 locals ()

       JE              G78,#38 [FALSE] L0001
       PRINT_RET       "The chests are all empty."
L0001: JE              G78,#12,#2b,#5d [FALSE] L0002
       CALL            R0116 (#c8) -> -(SP)
       PRINT_RET       "The chests are so rusty and corroded that they crumble
when you touch them."
L0002: JE              G78,#2b [FALSE] RFALSE
       PRINT_RET       "The chests are already open."

Routine R0322, 1 local (0000)

       JE              G00,#c7 [TRUE] L0001
       PUSH            #00
       JUMP            L0002
L0001: PUSH            #01
L0002: STORE           L00,(SP)+
       JZ              L00 [TRUE] L0003
       PRINT           "The water level here is now "
       DIV             G24,#02 -> -(SP)
       LOADW           G25,(SP)+ -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
L0003: INC             G24
       JL              G24,#0e [TRUE] L0004
       CALL            R0254 (#c7,S226) -> -(SP)
       CALL            R0022 (#5f89,#00) -> -(SP)
       JZ              L00 [TRUE] RTRUE
       CALL            R0431 (S227) -> -(SP)
       RTRUE           
L0004: JIN             G6f,"magic boat" [FALSE] RTRUE
       JE              G00,#c7,#d7,#9a [FALSE] RTRUE
       CALL            R0431 (S228) -> -(SP)
       RTRUE           

Routine R0323, 0 locals ()

       JG              G24,#00 [FALSE] RFALSE
       JE              G78,#32,#12 [FALSE] L0001
       JE              G76,#62 [FALSE] L0001
       CALL            R0324 -> -(SP)
       RET_POPPED      
L0001: JE              G78,#5f [FALSE] RFALSE
       JE              G77,#62 [FALSE] L0002
       CALL            R0324 -> -(SP)
       RET_POPPED      
L0002: CALL            R0328 (G77) -> -(SP)
       RET_POPPED      

Routine R0324, 0 locals ()

       STORE           G24,#ffff
       CALL            R0022 (#5f89,#00) -> -(SP)
       PRINT_RET       "By some miracle of Zorkian technology, you have managed
to stop the leak in the dam."

Routine R0325, 0 locals ()

       JE              G78,#55 [FALSE] L0001
       JE              G77,#62 [TRUE] L0002
L0001: JE              G78,#12 [FALSE] RFALSE
       JE              G76,#62 [FALSE] RFALSE
L0002: PRINT_RET       "The all-purpose gunk isn't a lubricant."

Routine R0326, 0 locals ()

       JE              G78,#12 [FALSE] L0001
       JE              G77,#63 [FALSE] L0001
       PRINT_RET       "The tube refuses to accept anything."
L0001: JE              G78,#79 [FALSE] RFALSE
       TEST_ATTR       G76,#0b [FALSE] L0002
       JIN             "viscous material",G76 [FALSE] L0002
       INSERT_OBJ      "viscous material",G6f
       PRINT_RET       "The viscous material oozes into your hand."
L0002: TEST_ATTR       G76,#0b [FALSE] L0003
       PRINT_RET       "The tube is apparently empty."
L0003: PRINT_RET       "The tube is closed."

Routine R0327, 0 locals ()

       JE              G78,#23,#2b [FALSE] L0001
       PRINT_RET       "Sounds reasonable, but this isn't how."
L0001: JE              G78,#5f [FALSE] RFALSE
       JE              G77,#01 [FALSE] L0002
       PRINT_RET       "Are you the little Dutch boy, then? Sorry, this is a
big dam."
L0002: PRINT           "With a "
       PRINT_OBJ       G77
       PRINT_RET       "? Do you know how big this dam is? You could only stop
a tiny leak with that."

Routine R0328, 1 local (0000)

       PRINT           "With a "
       PRINT_OBJ       L00
       PRINT_RET       "?"

Routine R0329, 1 local (0000)

       JE              L00,#03 [FALSE] RFALSE
       JZ              G90 [TRUE] L0001
       JZ              G27 [TRUE] L0001
       PRINT           "You are in a long room, to the north of which was
formerly a lake. However, with the water level lowered, there is merely a wide
stream running through the center of the room."
       JUMP            L0004
L0001: JZ              G27 [TRUE] L0002
       PRINT           "You are in a long room. To the north is a large lake,
too deep to cross. You notice, however, that the water level appears to be
dropping at a rapid rate. Before long, it might be possible to cross to the
other side from here."
       JUMP            L0004
L0002: JZ              G90 [TRUE] L0003
       PRINT           "You are in a long room, to the north of which is a wide
area which was formerly a reservoir, but now is merely a stream. You notice,
however, that the level of the stream is rising quickly and that before long it
will be impossible to cross here."
       JUMP            L0004
L0003: PRINT           "You are in a long room on the south shore of a large
lake, far too deep and wide for crossing."
L0004: NEW_LINE        
       PRINT_RET       "There is a path along the stream to the east or west, a
steep pathway climbing southwest along the edge of a chasm, and a path leading
into a canyon to the southeast."

Routine R0330, 1 local (0000)

       JE              L00,#06 [FALSE] L0001
       GET_PARENT      G6f -> -(SP)
       TEST_ATTR       (SP)+,#1b [TRUE] L0001
       JZ              G27 [FALSE] L0001
       JZ              G90 [TRUE] L0001
       PRINT_RET       "You notice that the water level here is rising rapidly.
The currents are also becoming stronger. Staying here seems quite perilous!"
L0001: JE              L00,#03 [FALSE] RFALSE
       JZ              G90 [TRUE] L0002
       PRINT           "You are on what used to be a large lake, but which is
now a large mud pile. There are "shores" to the north and south."
       JUMP            L0003
L0002: PRINT           "You are on the lake. Beaches can be seen north and
south. Upstream a small stream enters the lake through a narrow cleft in the
rocks. The dam can be seen downstream."
L0003: NEW_LINE        
       RTRUE           

Routine R0331, 1 local (0000)

       JE              L00,#03 [FALSE] RFALSE
       JZ              G90 [TRUE] L0001
       JZ              G27 [TRUE] L0001
       PRINT           "You are in a large cavernous room, the south of which
was formerly a lake. However, with the water level lowered, there is merely a
wide stream running through there."
       JUMP            L0004
L0001: JZ              G27 [TRUE] L0002
       PRINT           "You are in a large cavernous area. To the south is a
wide lake, whose water level appears to be falling rapidly."
       JUMP            L0004
L0002: JZ              G90 [TRUE] L0003
       PRINT           "You are in a cavernous area, to the south of which is a
very wide stream. The level of the stream is rising rapidly, and it appears
that before long it will be impossible to cross to the other side."
       JUMP            L0004
L0003: PRINT           "You are in a large cavernous room, north of a large
lake."
L0004: NEW_LINE        
       PRINT_RET       "There is a slimy stairway leaving the room to the
north."

Routine R0332, 1 local (0000)

       JE              G78,#7f [FALSE] L0001
       JE              G76,#ec [FALSE] L0001
       CALL            R0116 (G76) -> -(SP)
       STORE           L00,#01
       PRINT           "The bottle hits the far wall and shatters."
       NEW_LINE        
       JUMP            L0003
L0001: JE              G78,#2a [FALSE] L0002
       STORE           L00,#01
       CALL            R0116 (G76) -> -(SP)
       PRINT           "A brilliant maneuver destroys the bottle."
       NEW_LINE        
       JUMP            L0003
L0002: JE              G78,#73 [FALSE] L0003
       TEST_ATTR       G76,#0b [FALSE] L0003
       JIN             "quantity of water",G76 [FALSE] L0003
       STORE           L00,#01
L0003: JZ              L00 [TRUE] L0004
       JIN             "quantity of water",G76 [FALSE] L0004
       PRINT           "The water spills to the floor and evaporates."
       NEW_LINE        
       CALL            R0116 (#ed) -> -(SP)
       RTRUE           
L0004: JZ              L00 [TRUE] RFALSE
       RTRUE           

Routine R0333, 1 local (0000)

       STORE           L00,G23
       JE              G6f,#ba [FALSE] L0003
       JZ              G95 [TRUE] L0001
       PRINT_RET       "No use talking to him. He's fast asleep."
L0001: JE              G78,#5b [FALSE] L0002
       STORE           G6f,#04
       CALL            R0026 (#5b) -> -(SP)
       RTRUE           
L0002: PRINT_RET       "The cyclops prefers eating to making conversation."
L0003: JZ              G95 [TRUE] L0007
       JE              G78,#38 [FALSE] L0004
       PRINT_RET       "The cyclops is sleeping like a baby, albeit a very ugly
one."
L0004: JE              G78,#13,#46,#88 [TRUE] L0005
       JE              G78,#2a,#1c [FALSE] RFALSE
L0005: PRINT           "The cyclops yawns and stares at the thing that woke him
up."
       NEW_LINE        
       STORE           G95,#00
       SET_ATTR        "cyclops",#02
       JL              L00,#00 [FALSE] L0006
       SUB             #00,L00 -> G23
       RET             G23
L0006: STORE           G23,L00
       RET             G23
L0007: JE              G78,#38 [FALSE] L0008
       PRINT_RET       "A hungry cyclops is standing at the foot of the
stairs."
L0008: JE              G78,#3f [FALSE] L0015
       JE              G77,#ba [FALSE] L0015
       JE              G76,#e1 [FALSE] L0010
       JL              L00,#00 [TRUE] L0009
       CALL            R0116 (#e1) -> -(SP)
       PRINT           "The cyclops says "Mmm Mmm. I love hot peppers! But oh,
could I use a drink. Perhaps I could drink the blood of that thing."  From the
gleam in his eye, it could be surmised that you are "that thing"."
       NEW_LINE        
       SUB             #00,L00 -> -(SP)
       CALL            R0360 (#ffff,(SP)+) -> G23
L0009: CALL            R0022 (#649f,#ffff) -> -(SP)
       STOREW          (SP)+,#00,#01
       RTRUE           
L0010: JE              G76,#ed [TRUE] L0011
       JE              G76,#ec [FALSE] L0013
       JIN             "quantity of water","glass bottle" [FALSE] L0013
L0011: JL              L00,#00 [FALSE] L0012
       CALL            R0116 (#ed) -> -(SP)
       INSERT_OBJ      "glass bottle",G00
       SET_ATTR        "glass bottle",#0b
       CLEAR_ATTR      "cyclops",#02
       PRINT           "The cyclops takes the bottle, checks that it's open,
and drinks the water. A moment later, he lets out a yawn that nearly blows you
over, and then falls fast asleep (what did you put in that drink, anyway?)."
       NEW_LINE        
       STORE           G95,#01
       RET             G95
L0012: PRINT_RET       "The cyclops apparently is not thirsty and refuses your
generous offer."
L0013: JE              G76,#bd [FALSE] L0014
       PRINT_RET       "The cyclops may be hungry, but there is a limit."
L0014: PRINT_RET       "The cyclops is not so stupid as to eat THAT!"
L0015: JE              G78,#2a,#13,#7f [FALSE] L0017
       CALL            R0022 (#649f,#ffff) -> -(SP)
       STOREW          (SP)+,#00,#01
       JE              G78,#2a [FALSE] L0016
       PRINT_RET       ""Do you think I'm as stupid as my father was?", he
says, dodging."
L0016: PRINT           "The cyclops shrugs but otherwise ignores your pitiful
attempt."
       NEW_LINE        
       JE              G78,#7f [FALSE] RTRUE
       INSERT_OBJ      G76,G00
       RTRUE           
L0017: JE              G78,#5d [FALSE] L0018
       PRINT_RET       "The cyclops doesn't take kindly to being grabbed."
L0018: JE              G78,#82 [FALSE] L0019
       PRINT_RET       "You cannot tie the cyclops, though he is fit to be
tied."
L0019: JE              G78,#4d [FALSE] RFALSE
       PRINT_RET       "You can hear his stomach rumbling."

Routine R0334, 0 locals ()

       JZ              G95 [FALSE] RTRUE
       JZ              G3e [FALSE] RTRUE
       JE              G00,#b9 [TRUE] L0001
       CALL            R0023 (#649f) -> -(SP)
       STOREW          (SP)+,#00,#00
       RTRUE           
L0001: JL              G23,#00 [FALSE] L0002
       SUB             #00,G23 -> -(SP)
       JUMP            L0003
L0002: PUSH            G23
L0003: JG              (SP)+,#05 [FALSE] L0004
       CALL            R0023 (#649f) -> -(SP)
       STOREW          (SP)+,#00,#00
       CALL            R0431 (S229) -> -(SP)
       RET_POPPED      
L0004: JL              G23,#00 [FALSE] L0005
       DEC             G23
       JUMP            L0006
L0005: INC             G23
L0006: JZ              G95 [FALSE] RFALSE
       JL              G23,#00 [FALSE] L0007
       SUB             #00,G23 -> -(SP)
       JUMP            L0008
L0007: PUSH            G23
L0008: SUB             (SP)+,#01 -> -(SP)
       LOADW           G22,(SP)+ -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           

Routine R0335, 1 local (0000)

       JE              L00,#03 [FALSE] L0005
       PRINT           "This room has an exit on the northwest, and a staircase
leading up."
       NEW_LINE        
       JZ              G95 [TRUE] L0001
       JZ              G8f [FALSE] L0001
       PRINT_RET       "The cyclops is sleeping blissfully at the foot of the
stairs."
L0001: JZ              G8f [TRUE] L0002
       PRINT_RET       "The east wall, previously solid, now has a
cyclops-sized opening in it."
L0002: JZ              G23 [FALSE] L0003
       PRINT_RET       "A cyclops, who looks prepared to eat horses (much less
mere adventurers), blocks the staircase. From his state of health, and the
bloodstains on the walls, you gather that he is not very friendly, though he
likes people."
L0003: JG              G23,#00 [FALSE] L0004
       PRINT_RET       "The cyclops is standing in the corner, eyeing you
closely. I don't think he likes you very much. He looks extremely hungry, even
for a cyclops."
L0004: JL              G23,#00 [FALSE] RFALSE
       PRINT_RET       "The cyclops, having eaten the hot peppers, appears to
be gasping. His enflamed tongue protrudes from his man-sized mouth."
L0005: JE              L00,#02 [FALSE] RFALSE
       JZ              G23 [TRUE] RTRUE
       CALL            R0023 (#649f) -> -(SP)
       STOREW          (SP)+,#00,#01
       RTRUE           

Routine R0336, 2 locals (0000, 0000)

       JE              L00,#03 [FALSE] L0004
       PRINT           "This is a large room with a ceiling which cannot be
detected from the ground. There is a narrow passage from east to west and a
stone stairway leading upward."
       JZ              G21 [FALSE] L0001
       JZ              G27 [FALSE] L0002
       JZ              G90 [TRUE] L0002
L0001: PRINT           " The room is eerie in its quietness."
       JUMP            L0003
L0002: PRINT           " The room is deafeningly loud with an undetermined
rushing sound. The sound seems to reverberate from all of the walls, making it
difficult even to think."
L0003: NEW_LINE        
       RTRUE           
L0004: JE              L00,#06 [FALSE] L0005
       JZ              G27 [TRUE] L0005
       JZ              G90 [FALSE] L0005
       PRINT           "It is unbearably loud here, with an ear-splitting roar
seeming to come from all around you. There is a pounding in your head which
won't stop. With a tremendous effort, you scramble out of the room."
       NEW_LINE        
       NEW_LINE        
       CALL            R0004 (G26) -> -(SP)
       CALL            R0244 ((SP)+) -> -(SP)
       RFALSE          
L0005: JE              L00,#02 [FALSE] RFALSE
       JZ              G21 [FALSE] RFALSE
       JZ              G27 [FALSE] L0006
       JZ              G90 [FALSE] RFALSE
L0006: JZ              G27 [TRUE] L0007
       JZ              G90 [TRUE] RFALSE
L0007: CALL            R0226 -> -(SP)
       JZ              G6c [TRUE] L0008
       PRINT           "The rest of your commands have been lost in the noise."
       NEW_LINE        
       STORE           G6c,#00
L0008: NEW_LINE        
       PRINT           ">"
       READ            G6d,G6e
       LOADB           G6e,#01 -> -(SP)
       JZ              (SP)+ [FALSE] L0009
       PRINT           "I beg your pardon?"
       NEW_LINE        
       JUMP            L0008
L0009: LOADW           G6e,#01 -> L01
       JE              L01,"go","walk","run" [FALSE] L0010
       LOADW           G6e,#03 -> L01
       JUMP            L0011
L0010: JE              L01,"say" [FALSE] L0011
       LOADW           G6e,#05 -> L01
L0011: JE              L01,"save" [FALSE] L0012
       CALL            R0074 -> -(SP)
       JUMP            L0008
L0012: JE              L01,"restor" [FALSE] L0013
       CALL            R0073 -> -(SP)
       JUMP            L0008
L0013: JE              L01,"q","quit" [FALSE] L0014
       CALL            R0071 -> -(SP)
       JUMP            L0008
L0014: JE              L01,"w","west" [FALSE] L0015
       CALL            R0244 (#6b) -> -(SP)
       RET             (SP)+
L0015: JE              L01,"e","east" [FALSE] L0016
       CALL            R0244 (#27) -> -(SP)
       RET             (SP)+
L0016: JE              L01,"u","up" [FALSE] L0017
       CALL            R0244 (#28) -> -(SP)
       RET             (SP)+
L0017: JE              L01,"bug" [FALSE] L0018
       PRINT           "That's only your opinion."
       NEW_LINE        
       JUMP            L0008
L0018: JE              L01,"echo" [FALSE] L0019
       STORE           G21,#01
       CLEAR_ATTR      "platinum bar",#09
       PRINT           "The acoustics of the room change subtly."
       NEW_LINE        
       NEW_LINE        
       RTRUE           
L0019: CALL            R0114 -> -(SP)
       JUMP            L0008

Routine R0337, 1 local (0000)

       JE              L00,#03 [FALSE] RFALSE
       PRINT           "You are on the south edge of a deep canyon. Passages
lead off to the east, northwest and southwest. A stairway leads down."
       JZ              G27 [TRUE] L0001
       JZ              G90 [FALSE] L0001
       PRINT           " You can hear a loud roaring sound, like that of
rushing water, from below."
       JUMP            L0003
L0001: JZ              G27 [FALSE] L0002
       JZ              G90 [TRUE] L0002
       NEW_LINE        
       RTRUE           
L0002: PRINT           " You can hear the sound of flowing water from below."
L0003: NEW_LINE        
       RTRUE           

Routine R0338, 4 locals (0000, 0000, 0000, 0000)

       JZ              G3e [FALSE] L0001
       JE              G00,#be [TRUE] RFALSE
L0001: JZ              G1f [FALSE] L0015
       JZ              G3e [FALSE] L0003
       JZ              L00 [FALSE] L0003
       RANDOM          #64 -> -(SP)
       JG              #1e,(SP)+ [FALSE] L0003
       JIN             "stiletto","thief" [FALSE] L0002
       CLEAR_ATTR      "thief",#07
       PRINT           "Someone carrying a large bag is casually leaning
against one of the walls here. He does not speak, but it is clear from his
aspect that the bag will be taken only over his dead body."
       NEW_LINE        
       STORE           G1f,#01
       RTRUE           
L0002: JIN             "stiletto",G6f [FALSE] RFALSE
       INSERT_OBJ      "stiletto","thief"
       SET_ATTR        "stiletto",#0e
       CLEAR_ATTR      "thief",#07
       PRINT           "You feel a light finger-touch, and turning, notice a
grinning figure holding a large bag in one hand and a stiletto in the other."
       STORE           G1f,#01
       RTRUE           
L0003: JZ              L00 [TRUE] L0004
       TEST_ATTR       "thief",#02 [FALSE] L0004
       CALL            R0418 (#72) -> -(SP)
       JZ              (SP)+ [FALSE] L0004
       PRINT           "Your opponent, determining discretion to be the better
part of valor, decides to terminate this little contretemps. With a rueful nod
of his head, he steps backward into the gloom and disappears."
       NEW_LINE        
       SET_ATTR        "thief",#07
       CLEAR_ATTR      "thief",#02
       CALL            R0426 -> -(SP)
       RTRUE           
L0004: JZ              L00 [TRUE] L0005
       TEST_ATTR       "thief",#02 [FALSE] L0005
       RANDOM          #64 -> -(SP)
       JG              #5a,(SP)+ [TRUE] RFALSE
L0005: JZ              L00 [TRUE] L0006
       RANDOM          #64 -> -(SP)
       JG              #1e,(SP)+ [FALSE] L0006
       PRINT           "The holder of the large bag just left, looking
disgusted. Fortunately, he took nothing."
       NEW_LINE        
       SET_ATTR        "thief",#07
       CALL            R0426 -> -(SP)
       RTRUE           
L0006: RANDOM          #64 -> -(SP)
       JG              #46,(SP)+ [TRUE] RFALSE
       JZ              G3e [FALSE] RFALSE
       CALL            R0428 (G00,#72,#64) -> -(SP)
       JZ              (SP)+ [TRUE] L0007
       STORE           L01,#01
       JUMP            L0008
L0007: CALL            R0428 (G6f,#72) -> -(SP)
       JZ              (SP)+ [TRUE] L0008
       STORE           L01,#01
       STORE           L02,#01
L0008: STORE           G1f,#01
       JZ              L01 [TRUE] L0009
       JZ              L00 [FALSE] L0009
       PRINT           "A seedy-looking individual with a large bag just
wandered through the room. On the way through, he quietly abstracted some
valuables from the room and from your possession, mumbling something about
"Doing unto others before...""
       NEW_LINE        
       CALL            R0339 -> -(SP)
       RFALSE          
L0009: JZ              L00 [TRUE] L0014
       CALL            R0426 -> -(SP)
       JZ              L01 [TRUE] L0012
       PRINT           "The thief just left, still carrying his large bag. You
may not have noticed that he "
       JZ              L02 [TRUE] L0010
       PRINT           "robbed you blind first."
       JUMP            L0011
L0010: PRINT           "appropriated the valuables in the room."
L0011: NEW_LINE        
       CALL            R0339 -> -(SP)
       JUMP            L0013
L0012: PRINT           "The thief, finding nothing of value, left disgusted."
       NEW_LINE        
L0013: SET_ATTR        "thief",#07
       STORE           L00,#00
       RTRUE           
L0014: PRINT_RET       "A "lean and hungry" gentleman just wandered through,
carrying a large bag. Finding nothing of value, he left disgruntled."
L0015: JZ              L00 [TRUE] RFALSE
       RANDOM          #64 -> -(SP)
       JG              #1e,(SP)+ [FALSE] RFALSE
       CALL            R0428 (G00,#72,#64) -> -(SP)
       PULL            L03
       JZ              L03 [TRUE] L0016
       PUSH            L03
       JUMP            L0017
L0016: CALL            R0428 (G6f,#72) -> -(SP)
L0017: PULL            L01
       JZ              L01 [TRUE] L0018
       PRINT           "The thief just left, still carrying his large bag. You
may not have noticed that he robbed you blind first."
       NEW_LINE        
       CALL            R0339 -> -(SP)
       JUMP            L0019
L0018: PRINT           "The thief, finding nothing of value, left disgusted."
       NEW_LINE        
L0019: SET_ATTR        "thief",#07
       STORE           L00,#00
       CALL            R0426 -> -(SP)
       RFALSE          

Routine R0339, 1 local (0000)

       STORE           L00,G42
       CALL            R0063 (G00) -> G42
       JZ              G42 [FALSE] RTRUE
       JZ              L00 [TRUE] RTRUE
       PRINT_RET       "The thief seems to have left you in the dark."

Routine R0340, 1 local (0000)

       CALL            R0426 -> -(SP)
       SET_ATTR        "thief",#07
       GET_CHILD       "Treasure Room" -> L00 [TRUE] L0001
L0001: JZ              L00 [TRUE] RTRUE
       CLEAR_ATTR      L00,#07
       GET_SIBLING     L00 -> L00 [TRUE] L0002
L0002: JUMP            L0001

Routine R0341, 4 locals (0000, 0000, 0000, 0000)

       GET_CHILD       "thief" -> L01 [TRUE] L0001
L0001: JZ              L01 [FALSE] L0002
       RET             L03
L0002: GET_SIBLING     L01 -> L02 [TRUE] L0003
L0003: JE              L01,#71,#73 [FALSE] L0004
       JUMP            L0005
L0004: GET_PROP        L01,#0c -> -(SP)
       JG              (SP)+,#00 [FALSE] L0005
       INSERT_OBJ      L01,L00
       STORE           L03,#01
       JE              L01,#57 [FALSE] L0005
       STORE           G20,#01
       SET_ATTR        "jewel-encrusted egg",#0b
L0005: STORE           L01,L02
       JUMP            L0001

Routine R0342, 3 locals (0000, 0000, 0000)

       GET_CHILD       L00 -> L01 [TRUE] L0001
L0001: JZ              L01 [TRUE] RFALSE
       GET_SIBLING     L01 -> L02 [TRUE] L0002
L0002: TEST_ATTR       L01,#11 [FALSE] L0003
       TEST_ATTR       L01,#07 [TRUE] L0003
       RANDOM          #64 -> -(SP)
       JG              #28,(SP)+ [FALSE] L0003
       PRINT           "You hear, off in the distance, someone saying "My, I
wonder what this fine "
       PRINT_OBJ       L01
       PRINT           " is doing here.""
       NEW_LINE        
       CALL            R0002 (#3c) -> -(SP)
       JZ              (SP)+ [TRUE] RTRUE
       INSERT_OBJ      L01,"thief"
       SET_ATTR        L01,#03
       SET_ATTR        L01,#07
       RTRUE           
L0003: STORE           L01,L02
       JUMP            L0001

Routine R0343, 4 locals (0000, 0000, 0000, 0000)

       JE              G78,#6f [FALSE] L0001
       PRINT           "The thief is a strong, silent type."
       NEW_LINE        
       STORE           G6c,#00
       RET             G6c
L0001: JZ              L00 [FALSE] L0012
       JE              G78,#42 [FALSE] L0002
       GET_PROP        "thief",#0b -> -(SP)
       JE              (SP)+,G1c [FALSE] L0002
       PRINT_RET       "The thief, being temporarily incapacitated, is unable
to acknowledge your greeting with his usual graciousness."
L0002: JE              G76,#a9 [FALSE] L0006
       JE              G78,#7f [FALSE] L0006
       TEST_ATTR       "thief",#02 [TRUE] L0006
       CALL            R0002 (#0a) -> -(SP)
       JZ              (SP)+ [TRUE] L0005
       PRINT           "You evidently frightened the robber, though you didn't
hit him. He flees"
       GET_CHILD       "thief" -> L02 [FALSE] L0003
       CALL            R0345 (#72,G00) -> -(SP)
       PRINT           ", but the contents of his bag fall on the floor."
       JUMP            L0004
L0003: PRINT           "."
L0004: NEW_LINE        
       SET_ATTR        "thief",#07
       RTRUE           
L0005: PRINT           "You missed. The thief makes no attempt to take the
knife, though it would be a fine addition to the collection in his bag. He does
seem angered by your attempt."
       NEW_LINE        
       SET_ATTR        "thief",#02
       RTRUE           
L0006: JE              G78,#3f,#7f [FALSE] L0009
       JZ              G76 [TRUE] L0009
       JE              G76,#72 [TRUE] L0009
       JE              G77,#72 [FALSE] L0009
       GET_PROP        "thief",#07 -> -(SP)
       JL              (SP)+,#00 [FALSE] L0007
       GET_PROP        "thief",#07 -> -(SP)
       SUB             #00,(SP)+ -> -(SP)
       PUT_PROP        "thief",#07,(SP)+
       CALL            R0023 (#80f0) -> -(SP)
       STOREW          (SP)+,#00,#01
       CALL            R0426 -> -(SP)
       PUT_PROP        "thief",#0b,G1d
       PRINT           "Your proposed victim suddenly recovers consciousness."
       NEW_LINE        
L0007: INSERT_OBJ      G76,"thief"
       GET_PROP        G76,#0c -> -(SP)
       JG              (SP)+,#00 [FALSE] L0008
       STORE           G1e,#01
       PRINT           "The thief is taken aback by your unexpected generosity,
but accepts the "
       PRINT_OBJ       G76
       PRINT_RET       " and stops to admire its beauty."
L0008: PRINT           "The thief places the "
       PRINT_OBJ       G76
       PRINT_RET       " in his bag and thanks you politely."
L0009: JE              G78,#5d [FALSE] L0010
       PRINT_RET       "Once you got him, what would you do with him?"
L0010: JE              G78,#39,#38 [FALSE] L0011
       PRINT_RET       "The thief is a slippery character with beady eyes that
flit back and forth. He carries, along with an unmistakable arrogance, a large
bag over his shoulder and a vicious stiletto, whose blade is aimed menacingly
in your direction. I'd watch out if I were you."
L0011: JE              G78,#4d [FALSE] RFALSE
       PRINT_RET       "The thief says nothing, as you have not been formally
introduced."
L0012: JE              L00,#01 [FALSE] L0013
       JIN             "stiletto","thief" [TRUE] RFALSE
       GET_PARENT      "thief" -> -(SP)
       JIN             "stiletto",(SP)+ [FALSE] RFALSE
       INSERT_OBJ      "stiletto","thief"
       SET_ATTR        "stiletto",#0e
       JIN             "thief",G00 [FALSE] RTRUE
       PRINT           "The robber, somewhat surprised at this turn of events,
nimbly retrieves his stiletto."
       NEW_LINE        
       RTRUE           
L0013: JE              L00,#02 [FALSE] L0022
       INSERT_OBJ      "stiletto",G00
       CLEAR_ATTR      "stiletto",#0e
       CALL            R0341 (G00) -> L02
       JE              G00,#be [FALSE] L0020
       GET_CHILD       G00 -> L02 [TRUE] L0014
L0014: JZ              L02 [FALSE] L0015
       PRINT           "The chalice is now safe to take."
       NEW_LINE        
       JUMP            L0021
L0015: JE              L02,#bf,#72,#04 [TRUE] L0018
       CLEAR_ATTR      L02,#07
       JZ              L01 [FALSE] L0016
       STORE           L01,#01
       PRINT           "As the thief dies, the power of his magic decreases,
and his treasures reappear:"
       NEW_LINE        
L0016: PRINT           "  A "
       PRINT_OBJ       L02
       GET_CHILD       L02 -> -(SP) [FALSE] L0017
       CALL            R0233 (L02) -> -(SP)
       JZ              (SP)+ [TRUE] L0017
       PRINT           ", with "
       CALL            R0230 (L02) -> -(SP)
L0017: NEW_LINE        
L0018: GET_SIBLING     L02 -> L02 [TRUE] L0019
L0019: JUMP            L0014
L0020: JZ              L02 [TRUE] L0021
       PRINT           "His booty remains."
       NEW_LINE        
L0021: CALL            R0023 (#80f0) -> -(SP)
       STOREW          (SP)+,#00,#00
       RTRUE           
L0022: JE              L00,#05 [FALSE] L0023
       JZ              G1f [TRUE] RFALSE
       TEST_ATTR       "thief",#07 [TRUE] RFALSE
       RANDOM          #64 -> -(SP)
       JG              #14,(SP)+ [FALSE] RFALSE
       SET_ATTR        "thief",#02
       STORE           G6c,#00
       RTRUE           
L0023: JE              L00,#03 [FALSE] L0024
       CALL            R0023 (#80f0) -> -(SP)
       STOREW          (SP)+,#00,#00
       CLEAR_ATTR      "thief",#02
       INSERT_OBJ      "stiletto",G00
       CLEAR_ATTR      "stiletto",#0e
       PUT_PROP        "thief",#0b,G1c
       RTRUE           
L0024: JE              L00,#04 [FALSE] RFALSE
       GET_PARENT      "thief" -> -(SP)
       JE              (SP)+,G00 [FALSE] L0025
       SET_ATTR        "thief",#02
       PRINT           "The robber revives, briefly feigning continued
unconsciousness, and, when he sees his moment, scrambles away from you."
       NEW_LINE        
L0025: CALL            R0023 (#80f0) -> -(SP)
       STOREW          (SP)+,#00,#01
       PUT_PROP        "thief",#0b,G1d
       CALL            R0426 -> -(SP)
       RET_POPPED      

Routine R0344, 0 locals ()

       JE              G78,#5d [FALSE] L0002
       GET_PROP        "thief",#0b -> -(SP)
       JE              (SP)+,G1c [FALSE] L0001
       PRINT_RET       "Sadly for you, the robber collapsed on top of the bag.
Trying to take it would wake him."
L0001: PRINT_RET       "The bag will be taken over his dead body."
L0002: JE              G78,#12 [FALSE] L0003
       JE              G77,#73 [FALSE] L0003
       PRINT_RET       "It would be a good trick."
L0003: JE              G78,#23,#2b [FALSE] L0004
       PRINT_RET       "Getting close enough would be a good trick."
L0004: JE              G78,#39,#38 [FALSE] RFALSE
       PRINT_RET       "The bag is underneath the thief, so one can't say what,
if anything, is inside."

Routine R0345, 4 locals (0000, 0000, 0000, 0000)

       GET_CHILD       L00 -> L02 [FALSE] RFALSE
L0001: JZ              L02 [TRUE] RTRUE
       GET_SIBLING     L02 -> L03 [TRUE] L0002
L0002: CLEAR_ATTR      L02,#07
       INSERT_OBJ      L02,L01
       STORE           L02,L03
       JUMP            L0001

Routine R0346, 0 locals ()

       JE              G78,#5d [FALSE] L0001
       JIN             G76,"Treasure Room" [FALSE] RFALSE
       JIN             "thief","Treasure Room" [FALSE] RFALSE
       TEST_ATTR       "thief",#02 [FALSE] RFALSE
       TEST_ATTR       "thief",#07 [TRUE] RFALSE
       GET_PROP        "thief",#0b -> -(SP)
       JE              (SP)+,G1c [TRUE] RFALSE
       PRINT_RET       "You'd be stabbed in the back first."
L0001: JE              G78,#12 [FALSE] L0002
       JE              G77,#bf [FALSE] L0002
       PRINT_RET       "You can't. It's not a very good chalice, is it?"
L0002: CALL            R0437 -> -(SP)
       RET_POPPED      

Routine R0347, 3 locals (0000, 0000, 0000)

       JE              L00,#02 [FALSE] RFALSE
       CALL            R0023 (#80f0) -> -(SP)
       LOADW           (SP)+,#00 -> -(SP)
       JE              (SP)+,#01 [FALSE] RFALSE
       JZ              G3e [FALSE] RFALSE
       JIN             "thief",G00 [TRUE] L0001
       PUSH            #01
       JUMP            L0002
L0001: PUSH            #00
L0002: STORE           L01,(SP)+
       JZ              L01 [TRUE] L0003
       PRINT           "You hear a scream of anguish as you violate the
robber's hideaway. Using passages unknown to you, he rushes to its defense."
       NEW_LINE        
       INSERT_OBJ      "thief",G00
       SET_ATTR        "thief",#02
       CLEAR_ATTR      "thief",#07
       JUMP            L0004
L0003: SET_ATTR        "thief",#02
L0004: CALL            R0348 -> -(SP)
       RET_POPPED      

Routine R0348, 2 locals (0000, 0000)

       GET_CHILD       G00 -> L00 [TRUE] L0001
L0001: JZ              L00 [TRUE] L0002
       GET_SIBLING     L00 -> -(SP) [FALSE] L0002
       PRINT           "The thief gestures mysteriously, and the treasures in
the room suddenly vanish."
       NEW_LINE        
       NEW_LINE        
L0002: JZ              L00 [TRUE] RTRUE
       JE              L00,#bf [TRUE] L0003
       JE              L00,#72 [TRUE] L0003
       SET_ATTR        L00,#07
L0003: GET_SIBLING     L00 -> L00 [TRUE] L0004
L0004: JUMP            L0002

Routine R0349, 0 locals ()

       JE              G78,#2b [FALSE] L0001
       PRINT_RET       "The door cannot be opened."
L0001: JE              G78,#1c [FALSE] L0002
       PRINT_RET       "You cannot burn this door."
L0002: JE              G78,#2a [FALSE] L0003
       PRINT_RET       "You can't seem to damage the door."
L0003: JE              G78,#52 [FALSE] RFALSE
       PRINT_RET       "It won't open."

Routine R0350, 0 locals ()

       JE              G78,#5d [FALSE] L0001
       PRINT_RET       "A force keeps you from taking the bodies."
L0001: JE              G78,#1c,#2a [FALSE] RFALSE
       CALL            R0431 (S238) -> -(SP)
       RET_POPPED      

Routine R0351, 0 locals ()

       JE              G78,#2b [FALSE] L0001
       PRINT_RET       "The book is already open to page 569."
L0001: JE              G78,#23 [FALSE] L0002
       PRINT_RET       "As hard as you try, the book cannot be closed."
L0002: JE              G78,#59 [TRUE] L0003
       JE              G78,#6b [FALSE] L0004
       JE              G77,#0e [FALSE] L0004
       JE              G5e,#0239 [TRUE] L0004
L0003: PRINT_RET       "Beside page 569, there is only one other page with any
legible printing on it. Most of it is unreadable, but the subject seems to be
the banishment of evil. Apparently, certain noises, lights, and prayers are
efficacious in this regard."
L0004: JE              G78,#1c [FALSE] RFALSE
       CALL            R0116 (G76) -> -(SP)
       CALL            R0431 (S239) -> -(SP)
       RET_POPPED      

Routine R0352, 0 locals ()

       JE              G78,#2a [FALSE] RFALSE
       PUT_PROP        G76,#0c,#00
       PUT_PROP        G76,#0b,S240
       PRINT_RET       "Congratulations! Unlike the other vandals, who merely
stole the artist's masterpieces, you have destroyed one."

Routine R0353, 0 locals ()

       JE              G78,#7f [FALSE] L0001
       PRINT           "The lamp has smashed into the floor, and the light has
gone out."
       NEW_LINE        
       CALL            R0023 (#6f55) -> -(SP)
       STOREW          (SP)+,#00,#00
       CALL            R0116 (#a4) -> -(SP)
       INSERT_OBJ      "broken lantern",G00
       RTRUE           
L0001: JE              G78,#0e [FALSE] L0003
       TEST_ATTR       "brass lantern",#12 [FALSE] L0002
       PRINT_RET       "A burned-out lamp won't light."
L0002: CALL            R0023 (#6f55) -> -(SP)
       STOREW          (SP)+,#00,#01
       RFALSE          
L0003: JE              G78,#16 [FALSE] L0005
       TEST_ATTR       "brass lantern",#12 [FALSE] L0004
       PRINT_RET       "The lamp has already burned out."
L0004: CALL            R0023 (#6f55) -> -(SP)
       STOREW          (SP)+,#00,#00
       RFALSE          
L0005: JE              G78,#38 [FALSE] RFALSE
       PRINT           "The lamp "
       TEST_ATTR       "brass lantern",#12 [FALSE] L0006
       PRINT           "has burned out."
       JUMP            L0008
L0006: TEST_ATTR       "brass lantern",#14 [FALSE] L0007
       PRINT           "is on."
       JUMP            L0008
L0007: PRINT           "is turned off."
L0008: NEW_LINE        
       RTRUE           

Routine R0354, 0 locals ()

       JE              G78,#5d [FALSE] RFALSE
       JE              G76,#a0 [FALSE] RFALSE
       PRINT_RET       "It is securely anchored."

Routine R0355, 1 local (0000)

       JE              G78,#1c,#0e [FALSE] L0004
       JE              G76,#9b [FALSE] L0004
       JG              G1a,#00 [FALSE] L0001
       DEC             G1a
L0001: JG              G1a,#00 [TRUE] L0002
       PRINT_RET       "I'm afraid that you have run out of matches."
L0002: JE              G00,#e4,#ce [FALSE] L0003
       PRINT_RET       "This room is drafty, and the match goes out instantly."
L0003: SET_ATTR        "matchbook",#19
       SET_ATTR        "matchbook",#14
       CALL            R0022 (#6f46,#02) -> -(SP)
       STOREW          (SP)+,#00,#01
       PRINT           "One of the matches starts to burn."
       NEW_LINE        
       JZ              G42 [FALSE] RTRUE
       STORE           G42,#01
       CALL            R0144 -> -(SP)
       RTRUE           
L0004: JE              G78,#16 [FALSE] L0006
       TEST_ATTR       "matchbook",#19 [FALSE] L0006
       PRINT           "The match is out."
       NEW_LINE        
       CLEAR_ATTR      "matchbook",#19
       CLEAR_ATTR      "matchbook",#14
       CALL            R0063 (G00) -> G42
       JZ              G42 [FALSE] L0005
       PRINT           "It's pitch black in here!"
       NEW_LINE        
L0005: CALL            R0022 (#6f46,#00) -> -(SP)
       RTRUE           
L0006: JE              G78,#2b,#25 [FALSE] L0011
       PRINT           "You have "
       SUB             G1a,#01 -> L00
       JG              L00,#00 [TRUE] L0007
       PRINT           "no"
       JUMP            L0008
L0007: PRINT_NUM       L00
L0008: PRINT           " match"
       JE              L00,#01 [TRUE] L0009
       PRINT           "es."
       JUMP            L0010
L0009: PRINT           "."
L0010: NEW_LINE        
       RTRUE           
L0011: JE              G78,#38 [FALSE] RFALSE
       TEST_ATTR       "matchbook",#14 [FALSE] L0012
       PRINT           "The match is burning."
       JUMP            L0013
L0012: PRINT           "The matchbook isn't very interesting, except for what's
written on it."
L0013: NEW_LINE        
       RTRUE           

Routine R0356, 0 locals ()

       PRINT           "The match has gone out."
       NEW_LINE        
       CLEAR_ATTR      "matchbook",#19
       CLEAR_ATTR      "matchbook",#14
       CALL            R0063 (G00) -> G42
       RTRUE           

Routine R0357, 2 locals (0000, 0000)

       LOAD            G1b -> L01
       LOADW           L01,#00 -> L00
       CALL            R0022 (#6f55,L00) -> -(SP)
       STOREW          (SP)+,#00,#01
       CALL            R0359 (#a4,L01,L00) -> -(SP)
       JZ              L00 [TRUE] RFALSE
       ADD             L01,#04 -> G1b
       RET             G1b

Routine R0358, 2 locals (0000, 0000)

       LOAD            G19 -> L01
       SET_ATTR        "pair of candles",#03
       LOADW           L01,#00 -> L00
       CALL            R0022 (#6f6a,L00) -> -(SP)
       STOREW          (SP)+,#00,#01
       CALL            R0359 (#93,L01,L00) -> -(SP)
       JZ              L00 [TRUE] RFALSE
       ADD             L01,#04 -> G19
       RET             G19

Routine R0359, 3 locals (0000, 0000, 0000)

       JZ              L02 [FALSE] L0001
       CLEAR_ATTR      L00,#14
       SET_ATTR        L00,#12
L0001: CALL            R0252 (L00) -> -(SP)
       JZ              (SP)+ [FALSE] L0002
       JIN             L00,G00 [FALSE] RFALSE
L0002: JZ              L02 [FALSE] L0003
       PRINT           "You'd better have more light than from the "
       PRINT_OBJ       L00
       PRINT_RET       "."
L0003: LOADW           L01,#01 -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           

Routine R0360, 2 locals (0000, 0000)

       JL              L00,L01 [FALSE] L0001
       RET             L00
L0001: RET             L01

Routine R0361, 0 locals ()

       TEST_ATTR       "pair of candles",#03 [TRUE] L0001
       CALL            R0023 (#6f6a) -> -(SP)
       STOREW          (SP)+,#00,#01
L0001: JE              #93,G77 [TRUE] RFALSE
       JE              G78,#1c,#0e [FALSE] L0009
       TEST_ATTR       "pair of candles",#12 [FALSE] L0002
       PRINT_RET       "Alas, there's not much left of the candles. Certainly
not enough to burn."
L0002: JZ              G77 [FALSE] L0004
       TEST_ATTR       "matchbook",#19 [FALSE] L0003
       PRINT           "(with the match)"
       NEW_LINE        
       CALL            R0026 (#0e,#93,#9b) -> -(SP)
       RTRUE           
L0003: PRINT           "You should say what to light them with."
       NEW_LINE        
       RET             #02
L0004: JE              G77,#9b [FALSE] L0006
       TEST_ATTR       "matchbook",#14 [FALSE] L0006
       PRINT           "The candles are "
       TEST_ATTR       "pair of candles",#14 [FALSE] L0005
       PRINT_RET       "already lit."
L0005: SET_ATTR        "pair of candles",#14
       PRINT           "lit."
       NEW_LINE        
       CALL            R0023 (#6f6a) -> -(SP)
       STOREW          (SP)+,#00,#01
       RTRUE           
L0006: JE              G77,#68 [FALSE] L0008
       TEST_ATTR       "pair of candles",#14 [FALSE] L0007
       PRINT_RET       "You realize, just in time, that the candles are already
lighted."
L0007: PRINT           "The heat from the torch is so intense that the candles
are vaporized."
       NEW_LINE        
       CALL            R0116 (#93) -> -(SP)
       RET_POPPED      
L0008: PRINT_RET       "You have to light them with something that's burning,
you know."
L0009: JE              G78,#25 [FALSE] L0010
       PRINT_RET       "Let's see, how many objects in a pair? Don't tell me,
I'll get it."
L0010: JE              G78,#16 [FALSE] L0013
       CALL            R0023 (#6f6a) -> -(SP)
       STOREW          (SP)+,#00,#00
       TEST_ATTR       "pair of candles",#14 [FALSE] L0012
       PRINT           "The flame is extinguished."
       CLEAR_ATTR      "pair of candles",#14
       CALL            R0063 (G00) -> G42
       JZ              G42 [FALSE] L0011
       PRINT           " It's really dark in here...."
L0011: NEW_LINE        
       RTRUE           
L0012: PRINT_RET       "The candles are not lighted."
L0013: JE              G78,#12 [FALSE] L0014
       TEST_ATTR       G77,#1a [FALSE] L0014
       PRINT_RET       "That wouldn't be smart."
L0014: JE              G78,#38 [FALSE] RFALSE
       PRINT           "The candles are "
       TEST_ATTR       "pair of candles",#14 [FALSE] L0015
       PRINT           "burning."
       JUMP            L0016
L0015: PRINT           "out."
L0016: NEW_LINE        
       RTRUE           

Routine R0362, 1 local (0000)

       JE              L00,#06 [FALSE] RFALSE
       JIN             "pair of candles",G6f [FALSE] RFALSE
       CALL            R0002 (#32) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       TEST_ATTR       "pair of candles",#14 [FALSE] RFALSE
       CALL            R0023 (#6f6a) -> -(SP)
       STOREW          (SP)+,#00,#00
       CLEAR_ATTR      "pair of candles",#14
       PRINT           "A gust of wind blows out your candles!"
       NEW_LINE        
       CALL            R0063 (G00) -> G42
       JZ              G42 [FALSE] RFALSE
       PRINT_RET       "It is now completely dark."

Routine R0363, 1 local (0000)

       JE              G78,#5d [FALSE] L0001
       JE              G6f,#04 [FALSE] L0001
       CALL            R0022 (#807c,#ffff) -> -(SP)
       STOREW          (SP)+,#00,#01
       RFALSE          
L0001: JE              G78,#38 [FALSE] RFALSE
       GET_PROP        "sword",#0c -> L00
       JE              L00,#01 [FALSE] L0002
       PRINT_RET       "Your sword is glowing with a faint blue glow."
L0002: JE              L00,#02 [FALSE] RFALSE
       PRINT_RET       "Your sword is glowing very brightly."

Routine R0364, 3 locals (0000, 0000, 0000)

       JE              L00,#06 [FALSE] RFALSE
       JE              L00,#06 [FALSE] L0001
       JE              G78,#1c,#0e [FALSE] L0001
       JE              G76,#93,#68,#9b [FALSE] L0001
       STORE           L01,#01
L0001: CALL            R0252 (#93) -> -(SP)
       JZ              (SP)+ [TRUE] L0002
       TEST_ATTR       "pair of candles",#14 [TRUE] L0004
L0002: CALL            R0252 (#68) -> -(SP)
       JZ              (SP)+ [TRUE] L0003
       TEST_ATTR       "torch",#14 [TRUE] L0004
L0003: CALL            R0252 (#9b) -> -(SP)
       JZ              (SP)+ [TRUE] RFALSE
       TEST_ATTR       "matchbook",#14 [FALSE] RFALSE
L0004: JZ              L01 [TRUE] L0005
       PRINT           "How sad for an aspiring adventurer to light a "
       PRINT_OBJ       G76
       PRINT           " in a room which reeks of gas. Fortunately, there is
justice in the world."
       NEW_LINE        
       JUMP            L0006
L0005: PRINT           "Oh dear. It appears that the smell coming from this
room was coal gas. I would have thought twice about carrying flaming objects in
here."
       NEW_LINE        
L0006: CALL            R0431 (S247) -> -(SP)
       RET_POPPED      

Routine R0365, 1 local (0000)

       GET_PARENT      "clove of garlic" -> -(SP)
       JE              (SP)+,G6f,G00 [FALSE] L0001
       PRINT_RET       "In the corner of the room on the ceiling is a large
vampire bat who is obviously deranged and holding his nose."
L0001: PRINT_RET       "A large vampire bat, hanging from the ceiling, swoops
down at you!"

Routine R0366, 1 local (0000)

       JE              L00,#03 [FALSE] L0001
       PRINT_RET       "You are in a small room which has doors only to the
east and south."
L0001: JE              L00,#02 [FALSE] RFALSE
       JZ              G3e [FALSE] RFALSE
       GET_PARENT      "clove of garlic" -> -(SP)
       JE              (SP)+,G6f,G00 [TRUE] RFALSE
       CALL            R0144 -> -(SP)
       CALL            R0271 -> -(SP)
       RET_POPPED      

Routine R0367, 1 local (0000)

       JE              L00,#03 [FALSE] RFALSE
       PRINT           "This is a large, cold room whose sole exit is to the
north. In one corner there is a machine which is reminiscent of a clothes
dryer. On its face is a switch which is labelled "START". The switch does not
appear to be manipulable by any human hand (unless the fingers are about 1/16
by 1/4 inch). On the front of the machine is a large lid, which is "
       TEST_ATTR       "machine",#0b [FALSE] L0001
       PRINT           "open."
       JUMP            L0002
L0001: PRINT           "closed."
L0002: NEW_LINE        
       RTRUE           

Routine R0368, 0 locals ()

       JE              G78,#5d [FALSE] L0001
       PRINT_RET       "It is far too large to carry."
L0001: JE              G78,#2b [FALSE] L0004
       TEST_ATTR       "machine",#0b [FALSE] L0002
       CALL            R0004 (G34) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           
L0002: GET_CHILD       "machine" -> -(SP) [FALSE] L0003
       PRINT           "The lid opens, revealing "
       CALL            R0230 (#9e) -> -(SP)
       PRINT           "."
       NEW_LINE        
       SET_ATTR        "machine",#0b
       RTRUE           
L0003: PRINT           "The lid opens."
       NEW_LINE        
       SET_ATTR        "machine",#0b
       RTRUE           
L0004: JE              G78,#23 [FALSE] L0006
       TEST_ATTR       "machine",#0b [FALSE] L0005
       PRINT           "The lid closes."
       NEW_LINE        
       CLEAR_ATTR      "machine",#0b
       RTRUE           
L0005: CALL            R0004 (G34) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           
L0006: JE              G78,#0e [FALSE] RFALSE
       JZ              G77 [FALSE] L0007
       PRINT_RET       "It's not clear how to turn it on with your bare hands."
L0007: CALL            R0026 (#59,#70,G77) -> -(SP)
       RTRUE           

Routine R0369, 1 local (0000)

       JE              G78,#59 [FALSE] RFALSE
       JE              G77,#7b [FALSE] L0004
       TEST_ATTR       "machine",#0b [FALSE] L0001
       PRINT_RET       "The machine doesn't seem to want to do anything."
L0001: PRINT           "The machine comes to life (figuratively) with a
dazzling display of colored lights and bizarre noises. After a few moments, the
excitement abates."
       NEW_LINE        
       JIN             "small pile of coal","machine" [FALSE] L0002
       CALL            R0116 (#77) -> -(SP)
       INSERT_OBJ      "huge diamond","machine"
       RTRUE           
L0002: GET_CHILD       "machine" -> L00 [FALSE] L0003
       CALL            R0116 (L00) -> -(SP)
       JUMP            L0002
L0003: INSERT_OBJ      "small piece of vitreous slag","machine"
       RTRUE           
L0004: JZ              G77 [FALSE] L0005
       PRINT_RET       "You can't turn it with your hands..."
L0005: PRINT           "It seems that a "
       PRINT_OBJ       G77
       PRINT_RET       " won't do."

Routine R0370, 0 locals ()

       CALL            R0116 (#92) -> -(SP)
       PRINT_RET       "The slag was rather insubstantial, and crumbles into
dust at your touch."

Routine R0371, 2 locals (0000, 0000)

       JE              L00,#01 [FALSE] RFALSE
       GET_CHILD       G6f -> L01 [TRUE] L0001
L0001: STORE           G92,#01
L0002: JZ              L01 [FALSE] L0003
       JUMP            L0006
L0003: CALL            R0241 (L01) -> -(SP)
       JG              (SP)+,#04 [FALSE] L0004
       STORE           G92,#00
       JUMP            L0006
L0004: GET_SIBLING     L01 -> L01 [TRUE] L0005
L0005: JUMP            L0002
L0006: JE              G00,#e4 [FALSE] RFALSE
       JZ              G42 [TRUE] RFALSE
       CALL            R0234 (G18) -> -(SP)
       STORE           G18,#00
       RFALSE          

Routine R0372, 1 local (0000)

       JE              L00,#01 [FALSE] RFALSE
       JIN             "gold coffin",G6f [TRUE] L0001
       PUSH            #01
       JUMP            L0002
L0001: PUSH            #00
L0002: STORE           G8b,(SP)+
       RFALSE          

Routine R0373, 1 local (0000)

       JE              L00,#06 [FALSE] RFALSE
       JIN             "magic boat",G6f [FALSE] L0001
       STORE           G94,#00
       RET             G94
L0001: STORE           G94,#01
       RET             G94

Routine R0374, 0 locals ()

       JE              G78,#69,#8c [FALSE] RFALSE
       JE              G00,#1d [TRUE] L0001
       JE              G00,#88 [FALSE] L0004
L0001: JZ              G8e [FALSE] L0003
       CLEAR_ATTR      "pot of gold",#07
       PRINT           "Suddenly, the rainbow appears to become solid and, I
venture, walkable (I think the giveaway was the stairs and bannister)."
       NEW_LINE        
       JE              G00,#88 [FALSE] L0002
       JIN             "pot of gold","End of Rainbow" [FALSE] L0002
       PRINT           "A shimmering pot of gold appears at the end of the
rainbow."
       NEW_LINE        
L0002: STORE           G8e,#01
       RET             G8e
L0003: CALL            R0428 (#1c,#f6) -> -(SP)
       PRINT           "The rainbow seems to have become somewhat
run-of-the-mill."
       NEW_LINE        
       STORE           G8e,#00
       RET             G8e
L0004: JE              G00,#1c [FALSE] L0005
       STORE           G8e,#00
       CALL            R0431 (S248) -> -(SP)
       RET_POPPED      
L0005: PRINT_RET       "A dazzling display of color briefly emanates from the
sceptre."

Routine R0375, 1 local (0000)

       JE              L00,#03 [FALSE] RFALSE
       PRINT           "You are at the top of Aragain Falls, an enormous
waterfall with a drop of about 450 feet. The only path here is on the north
end."
       NEW_LINE        
       JZ              G8e [TRUE] L0001
       PRINT           "A solid rainbow spans the falls."
       JUMP            L0002
L0001: PRINT           "A beautiful rainbow can be seen over the falls and to
the west."
L0002: NEW_LINE        
       RTRUE           

Routine R0376, 0 locals ()

       JE              G78,#22,#26 [FALSE] L0005
       JE              G00,#19 [FALSE] L0001
       PRINT_RET       "From here?!?"
L0001: JZ              G8e [TRUE] L0004
       JE              G00,#1d [FALSE] L0002
       CALL            R0244 (#88) -> -(SP)
       RET_POPPED      
L0002: JE              G00,#88 [FALSE] L0003
       CALL            R0244 (#1d) -> -(SP)
       RET_POPPED      
L0003: PRINT_RET       "You'll have to say which way..."
L0004: PRINT_RET       "Can you walk on water vapor?"
L0005: JE              G78,#51 [FALSE] RFALSE
       PRINT_RET       "The Frigid River flows under the rainbow."

Routine R0377, 0 locals ()

       JE              G78,#32,#12 [FALSE] L0001
       JE              G76,#62 [FALSE] L0001
       CALL            R0378 -> -(SP)
       RET_POPPED      
L0001: JE              G78,#3b,#17 [FALSE] L0002
       PRINT_RET       "No chance. Some moron punctured it."
L0002: JE              G78,#5f [FALSE] RFALSE
       JE              G77,#62 [FALSE] L0003
       CALL            R0378 -> -(SP)
       RET_POPPED      
L0003: CALL            R0328 (G77) -> -(SP)
       RET_POPPED      

Routine R0378, 0 locals ()

       PRINT           "Well done. The boat is repaired."
       NEW_LINE        
       GET_PARENT      "punctured boat" -> -(SP)
       INSERT_OBJ      "pile of plastic",(SP)+
       CALL            R0116 (#8e) -> -(SP)
       RET_POPPED      

Routine R0379, 0 locals ()

       JE              G78,#12 [FALSE] L0004
       JE              G77,#83 [FALSE] RFALSE
       JE              G76,#05 [FALSE] L0001
       CALL            R0431 (S249) -> -(SP)
       RET_POPPED      
L0001: JE              G76,#9c [FALSE] L0002
       PRINT_RET       "You should get in the boat then launch it."
L0002: TEST_ATTR       G76,#1a [FALSE] L0003
       CALL            R0116 (G76) -> -(SP)
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " floats for a moment, then sinks."
L0003: CALL            R0116 (G76) -> -(SP)
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " splashes into the water and is gone forever."
L0004: JE              G78,#22,#45 [FALSE] RFALSE
       PRINT_RET       "A look before leaping reveals that the river is wide
and dangerous, with swift currents and large, half-hidden rocks. You decide to
forgo your swim."

Routine R0380, 1 local (0000)

       JE              G00,#24,#23,#22 [TRUE] L0001
       JE              G00,#82,#1f [TRUE] L0001
       CALL            R0023 (#74f1) -> -(SP)
       STOREW          (SP)+,#00,#00
       RTRUE           
L0001: CALL            R0246 (G00,G16) -> L00
       JZ              L00 [TRUE] L0002
       PRINT           "The flow of the river carries you downstream."
       NEW_LINE        
       NEW_LINE        
       CALL            R0244 (L00) -> -(SP)
       CALL            R0246 (G00,G17) -> -(SP)
       CALL            R0022 (#74f1,(SP)+) -> -(SP)
       STOREW          (SP)+,#00,#01
       RTRUE           
L0002: CALL            R0431 (S250) -> -(SP)
       RET_POPPED      

Routine R0381, 2 locals (0000, 0000)

       JE              L00,#02,#06,#03 [TRUE] RFALSE
       JE              L00,#01 [FALSE] L0018
       JE              G78,#89 [FALSE] L0003
       JE              G76,#13,#1e,#1d [TRUE] RFALSE
       JE              G00,#64 [FALSE] L0001
       JE              G76,#1f,#1c [TRUE] RFALSE
L0001: JE              G00,#30 [FALSE] L0002
       JE              G76,#1c [TRUE] RFALSE
L0002: PRINT_RET       "Read the label for the boat's instructions."
L0003: JE              G78,#4a [FALSE] L0010
       JE              G00,#24,#23,#22 [TRUE] L0004
       JE              G00,#82,#64,#30 [FALSE] L0008
L0004: PRINT           "You are on the "
       JE              G00,#64 [FALSE] L0005
       PRINT           "reservoir"
       JUMP            L0007
L0005: JE              G00,#30 [FALSE] L0006
       PRINT           "stream"
       JUMP            L0007
L0006: PRINT           "river"
L0007: PRINT_RET       ", or have you forgotten?"
L0008: CALL            R0245 (G15) -> L01
       JE              L01,#01 [FALSE] L0009
       CALL            R0246 (G00,G17) -> -(SP)
       CALL            R0022 (#74f1,(SP)+) -> -(SP)
       STOREW          (SP)+,#00,#01
       RTRUE           
L0009: JE              L01,#02 [TRUE] RTRUE
       PRINT_RET       "You can't launch it here."
L0010: JE              G78,#31 [FALSE] L0011
       TEST_ATTR       G76,#1d [TRUE] L0013
L0011: JE              G78,#12 [FALSE] L0012
       TEST_ATTR       G76,#1d [FALSE] L0012
       JE              G77,#9c [TRUE] L0013
L0012: JE              G78,#2a,#13 [FALSE] L0017
       TEST_ATTR       G77,#1d [FALSE] L0017
L0013: CALL            R0116 (#9c) -> -(SP)
       INSERT_OBJ      "punctured boat",G00
       CALL            R0428 (#9c,G00) -> -(SP)
       INSERT_OBJ      G6f,G00
       PRINT           "It seems that the "
       JE              G78,#12,#31 [FALSE] L0014
       PRINT_OBJ       G76
       JUMP            L0015
L0014: PRINT_OBJ       G77
L0015: PRINT           " didn't agree with the boat, as evidenced by the loud
hissing noise issuing therefrom. With a pathetic sputter, the boat deflates,
leaving you without."
       NEW_LINE        
       TEST_ATTR       G00,#04 [FALSE] RTRUE
       NEW_LINE        
       JE              G00,#64,#30 [FALSE] L0016
       CALL            R0431 (S251) -> -(SP)
       RTRUE           
L0016: CALL            R0431 (S252) -> -(SP)
       RTRUE           
L0017: JE              G78,#4a [FALSE] RFALSE
       PRINT_RET       "You're not in the boat!"
L0018: JE              G78,#19 [FALSE] L0020
       JIN             "sceptre",G6f [TRUE] L0019
       JIN             "nasty knife",G6f [TRUE] L0019
       JIN             "sword",G6f [TRUE] L0019
       JIN             "rusty knife",G6f [TRUE] L0019
       JIN             "bloody axe",G6f [TRUE] L0019
       JIN             "stiletto",G6f [FALSE] RFALSE
L0019: PRINT           "Oops! Something sharp seems to have slipped and
punctured the boat. The boat deflates to the sounds of hissing, sputtering, and
cursing."
       NEW_LINE        
       CALL            R0116 (#9c) -> -(SP)
       INSERT_OBJ      "punctured boat",G00
       CALL            R0255 (#8e) -> -(SP)
       RTRUE           
L0020: JE              G78,#3b,#17 [FALSE] L0021
       PRINT_RET       "Inflating it further would probably burst it."
L0021: JE              G78,#29 [FALSE] RFALSE
       GET_PARENT      G6f -> -(SP)
       JE              (SP)+,#9c [FALSE] L0022
       PRINT_RET       "You can't deflate the boat while you're in it."
L0022: JIN             "magic boat",G00 [TRUE] L0023
       PRINT_RET       "The boat must be on the ground to be deflated."
L0023: PRINT           "The boat deflates."
       NEW_LINE        
       STORE           G94,#01
       CALL            R0116 (#9c) -> -(SP)
       INSERT_OBJ      "pile of plastic",G00
       CALL            R0255 (#8d) -> -(SP)
       RET_POPPED      

Routine R0382, 0 locals ()

       CALL            R0026 (#17,G76,#06) -> -(SP)
       RET_POPPED      

Routine R0383, 0 locals ()

       JE              G78,#3b,#17 [FALSE] RFALSE
       JIN             "pile of plastic",G00 [TRUE] L0001
       PRINT_RET       "The boat must be on the ground to be inflated."
L0001: JE              G77,#ad [FALSE] L0003
       PRINT           "The boat inflates and appears seaworthy."
       NEW_LINE        
       TEST_ATTR       "tan label",#03 [TRUE] L0002
       PRINT           "A tan label is lying inside the boat."
       NEW_LINE        
L0002: STORE           G94,#00
       CALL            R0116 (#8d) -> -(SP)
       INSERT_OBJ      "magic boat",G00
       CALL            R0255 (#9c) -> -(SP)
       RET_POPPED      
L0003: JE              G77,#06 [FALSE] L0004
       PRINT_RET       "You don't have enough lung power to inflate it."
L0004: PRINT           "With a "
       PRINT_OBJ       G77
       PRINT_RET       "? Surely you jest!"

Routine R0384, 1 local (0000)

       JE              L00,#06 [FALSE] RFALSE
       JIN             "red buoy",G6f [FALSE] RFALSE
       JZ              G14 [TRUE] RFALSE
       PRINT           "You notice something funny about the feel of the buoy."
       NEW_LINE        
       STORE           G14,#00
       RET             G14

Routine R0385, 0 locals ()

       JE              G78,#2c [FALSE] RFALSE
       JE              G77,#79 [FALSE] RFALSE
       INC             G13
       JG              G13,#03 [FALSE] L0002
       STORE           G13,#ffff
       JIN             "beautiful jeweled scarab",G00 [FALSE] L0001
       SET_ATTR        "beautiful jeweled scarab",#07
L0001: CALL            R0431 (S253) -> -(SP)
       RET_POPPED      
L0002: JE              G13,#03 [FALSE] L0003
       TEST_ATTR       "beautiful jeweled scarab",#07 [FALSE] RFALSE
       PRINT           "You can see a scarab here in the sand."
       NEW_LINE        
       CALL            R0255 (#74) -> -(SP)
       CLEAR_ATTR      "beautiful jeweled scarab",#07
       RTRUE           
L0003: LOADW           G12,G13 -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           

Routine R0386, 2 locals (0000, 0000)

       JE              L00,#03 [FALSE] L0001
       PRINT           "You are about 10 feet above the ground nestled among
some large branches. The nearest branch above you is above your reach."
       NEW_LINE        
       GET_CHILD       "Forest Path" -> L01 [FALSE] RFALSE
       GET_SIBLING     L01 -> -(SP) [FALSE] RFALSE
       PRINT           "On the ground below you can see:  "
       CALL            R0230 (#4b) -> -(SP)
       PRINT_RET       "."
L0001: JE              L00,#01 [FALSE] L0007
       JE              G78,#1f [FALSE] L0002
       JE              G76,#f1 [FALSE] L0002
       CALL            R0247 (#16) -> -(SP)
       RET_POPPED      
L0002: JE              G78,#20,#1e [FALSE] L0003
       JE              G76,#f1 [FALSE] L0003
       CALL            R0247 (#17) -> -(SP)
       RET_POPPED      
L0003: JE              G78,#31 [FALSE] RFALSE
       CALL            R0239 -> -(SP)
       JZ              (SP)+ [TRUE] RTRUE
       JE              G76,#59 [FALSE] L0004
       JIN             "jewel-encrusted egg","bird's nest" [FALSE] L0004
       PRINT           "The nest falls to the ground, and the egg spills out of
it, seriously damaged."
       NEW_LINE        
       CALL            R0116 (#57) -> -(SP)
       INSERT_OBJ      "broken jewel-encrusted egg","Forest Path"
       RTRUE           
L0004: JE              G76,#57 [FALSE] L0005
       PRINT           "The egg falls to the ground and springs open, seriously
damaged."
       INSERT_OBJ      "jewel-encrusted egg","Forest Path"
       CALL            R0388 -> -(SP)
       NEW_LINE        
       RTRUE           
L0005: JE              G76,G6f,#f1 [TRUE] L0006
       INSERT_OBJ      G76,"Forest Path"
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " falls to the ground."
L0006: JE              G78,#45 [FALSE] RFALSE
       CALL            R0431 (S257) -> -(SP)
       RET_POPPED      
L0007: JE              L00,#02 [FALSE] RFALSE
       CALL            R0022 (#7954,#ffff) -> -(SP)
       STOREW          (SP)+,#00,#01
       RTRUE           

Routine R0387, 0 locals ()

       JE              G78,#2a,#2b [FALSE] L0007
       JE              G76,#57 [FALSE] L0007
       TEST_ATTR       G76,#0b [FALSE] L0001
       PRINT_RET       "The egg is already open."
L0001: JZ              G77 [FALSE] L0002
       PRINT_RET       "You have neither the tools nor the expertise."
L0002: JE              G77,#01 [FALSE] L0003
       PRINT_RET       "I doubt you could do that without damaging it."
L0003: TEST_ATTR       G77,#1d [TRUE] L0004
       TEST_ATTR       G77,#1c [TRUE] L0004
       JE              G78,#2a [FALSE] L0005
L0004: PRINT           "The egg is now open, but the clumsiness of your attempt
has seriously compromised its esthetic appeal."
       CALL            R0388 -> -(SP)
       NEW_LINE        
       RTRUE           
L0005: TEST_ATTR       G76,#02 [FALSE] L0006
       PRINT           "Not to say that using the "
       PRINT_OBJ       G77
       PRINT_RET       " isn't original too..."
L0006: PRINT           "The concept of using a "
       PRINT_OBJ       G77
       PRINT           " is certainly original."
       NEW_LINE        
       SET_ATTR        G76,#02
       RTRUE           
L0007: JE              G78,#41,#21 [FALSE] L0008
       PRINT           "There is a noticeable crunch from beneath you, and
inspection reveals that the egg is lying open, badly damaged."
       CALL            R0388 -> -(SP)
       NEW_LINE        
       RTRUE           
L0008: JE              G78,#7f,#2a,#2b [FALSE] RFALSE
       JE              G78,#7f [FALSE] L0009
       INSERT_OBJ      G76,G00
L0009: PRINT           "Your rather indelicate handling of the egg has caused
it some damage, although you have succeeded in opening it."
       CALL            R0388 -> -(SP)
       NEW_LINE        
       RTRUE           

Routine R0388, 1 local (0000)

       JIN             "golden clockwork canary","jewel-encrusted egg" [FALSE]
L0001
       PRINT           " "
       GET_PROP        "broken clockwork canary",#0e -> -(SP)
       PRINT_PADDR     (SP)+
       JUMP            L0002
L0001: CALL            R0116 (#53) -> -(SP)
L0002: GET_PARENT      "jewel-encrusted egg" -> -(SP)
       INSERT_OBJ      "broken jewel-encrusted egg",(SP)+
       CALL            R0116 (#57) -> -(SP)
       RTRUE           

Routine R0389, 0 locals ()

       JE              G78,#8e [FALSE] RFALSE
       JE              G76,#54 [FALSE] L0004
       JZ              G11 [FALSE] L0003
       CALL            R0390 -> -(SP)
       JZ              (SP)+ [TRUE] L0003
       PRINT           "The canary chirps, slightly off-key, an aria from a
forgotten opera. From out of the greenery flies a lovely songbird. It perches
on a limb just over your head and opens its beak to sing. As it does so a
beautiful brass bauble drops from its mouth, bounces off the top of your head,
and lands glimmering in the grass. As the canary winds down, the songbird flies
away."
       NEW_LINE        
       STORE           G11,#01
       JE              G00,#58 [FALSE] L0001
       PUSH            #4b
       JUMP            L0002
L0001: PUSH            G00
L0002: INSERT_OBJ      "beautiful brass bauble",(SP)+
       RTRUE           
L0003: PRINT_RET       "The canary chirps blithely, if somewhat tinnily, for a
short time."
L0004: PRINT_RET       "There is an unpleasant grinding noise from inside the
canary."

Routine R0390, 0 locals ()

       JE              G00,#4e,#4d,#4c [TRUE] RTRUE
       JE              G00,#4b,#58 [TRUE] RTRUE
       RFALSE          

Routine R0391, 0 locals ()

       CALL            R0390 -> -(SP)
       JZ              (SP)+ [FALSE] L0001
       CALL            R0023 (#7954) -> -(SP)
       STOREW          (SP)+,#00,#00
       RFALSE          
L0001: RANDOM          #64 -> -(SP)
       JG              #0f,(SP)+ [FALSE] RFALSE
       PRINT_RET       "You hear in the distance the chirping of a song bird."

Routine R0392, 1 local (0000)

       JE              L00,#02 [FALSE] L0001
       CALL            R0022 (#7954,#ffff) -> -(SP)
       STOREW          (SP)+,#00,#01
       RTRUE           
L0001: JE              L00,#01 [FALSE] RFALSE
       JE              G78,#1e,#20 [FALSE] RFALSE
       JE              G76,#f1 [FALSE] RFALSE
       CALL            R0247 (#17) -> -(SP)
       RET_POPPED      

Routine R0393, 0 locals ()

       JE              G78,#20,#1f,#1e [FALSE] RFALSE
       PRINT_RET       "The cliff is too steep for climbing."

Routine R0394, 0 locals ()

       JE              G78,#45 [TRUE] L0001
       JE              G78,#12 [FALSE] L0002
       JE              G76,#05 [FALSE] L0002
L0001: PRINT_RET       "That would be very unwise. Perhaps even fatal."
L0002: JE              G77,#5d [FALSE] RFALSE
       JE              G78,#81,#12 [FALSE] RFALSE
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " tumbles into the river and is seen no more."
       NEW_LINE        
       CALL            R0116 (G76) -> -(SP)
       RET_POPPED      

Routine R0395, 1 local (0000)

       JE              G00,#85 [TRUE] L0001
       STORE           G93,#00
       JE              G78,#82 [FALSE] RFALSE
       PRINT_RET       "You can't tie the rope to that."
L0001: JE              G78,#82 [FALSE] L0004
       JE              G77,#86 [FALSE] RFALSE
       JZ              G93 [TRUE] L0002
       PRINT_RET       "The rope is already tied to it."
L0002: PRINT           "The rope drops over the side and comes within ten feet
of the floor."
       NEW_LINE        
       STORE           G93,#01
       SET_ATTR        "rope",#0e
       GET_PARENT      "rope" -> L00
       JZ              L00 [TRUE] L0003
       JIN             L00,#52 [TRUE] RTRUE
L0003: INSERT_OBJ      "rope",G00
       RTRUE           
L0004: JE              G78,#1f [FALSE] L0005
       JE              G76,#81 [FALSE] L0005
       JZ              G93 [TRUE] L0005
       CALL            R0247 (#16) -> -(SP)
       RET_POPPED      
L0005: JE              G78,#83 [FALSE] L0008
       JE              #81,G77 [FALSE] L0008
       TEST_ATTR       G76,#1e [FALSE] L0007
       GET_PROP        G76,#07 -> -(SP)
       JL              (SP)+,#00 [FALSE] L0006
       PRINT           "Your attempt to tie up the "
       PRINT_OBJ       G76
       PRINT           " awakens him."
       CALL            R0421 (G76) -> -(SP)
       RET_POPPED      
L0006: PRINT           "The "
       PRINT_OBJ       G76
       PRINT_RET       " struggles and you cannot tie him up."
L0007: PRINT           "Why would you tie up a "
       PRINT_OBJ       G76
       PRINT_RET       "?"
L0008: JE              G78,#86 [FALSE] L0010
       JZ              G93 [TRUE] L0009
       STORE           G93,#00
       CLEAR_ATTR      "rope",#0e
       PRINT_RET       "The rope is now untied."
L0009: PRINT_RET       "It is not tied to anything."
L0010: JE              G78,#31 [FALSE] L0011
       JE              G00,#85 [FALSE] L0011
       JZ              G93 [FALSE] L0011
       INSERT_OBJ      "rope","Torch Room"
       PRINT_RET       "The rope drops gently to the floor below."
L0011: JE              G78,#5d [FALSE] RFALSE
       JZ              G93 [TRUE] RFALSE
       PRINT_RET       "The rope is tied to the railing."

Routine R0396, 0 locals ()

       JE              G76,#81 [FALSE] L0001
       JZ              G93 [TRUE] L0001
       JE              G77,#86 [FALSE] L0001
       CALL            R0026 (#86,G76) -> -(SP)
       RET_POPPED      
L0001: PRINT_RET       "It's not attached to that!"

Routine R0397, 0 locals ()

       JE              G78,#1f,#1e,#22 [TRUE] L0001
       JE              G78,#20 [TRUE] L0002
L0001: JE              G78,#12 [FALSE] L0004
       JE              G76,#05 [FALSE] L0004
L0002: JE              G00,#48 [FALSE] L0003
       CALL            R0247 (#1d) -> -(SP)
       RTRUE           
L0003: PRINT           "You tumble down the slide...."
       NEW_LINE        
       CALL            R0244 (#48) -> -(SP)
       RET_POPPED      
L0004: JE              G78,#12 [FALSE] RFALSE
       CALL            R0398 (G76) -> -(SP)
       RET_POPPED      

Routine R0398, 1 local (0000)

       TEST_ATTR       L00,#11 [FALSE] L0002
       PRINT           "The "
       PRINT_OBJ       L00
       PRINT           " falls into the slide and is gone."
       NEW_LINE        
       JE              L00,#ed [FALSE] L0001
       CALL            R0116 (L00) -> -(SP)
       RET_POPPED      
L0001: INSERT_OBJ      L00,"Cellar"
       RTRUE           
L0002: CALL            R0004 (G35) -> -(SP)
       PRINT_PADDR     (SP)+
       NEW_LINE        
       RTRUE           

Routine R0399, 0 locals ()

       JE              G78,#75 [FALSE] RFALSE
       JIN             "lunch",G76 [FALSE] RFALSE
       PRINT_RET       "It smells of hot peppers."

Routine R0400, 2 locals (0000, 0000)

       JE              G78,#89 [FALSE] L0001
       JE              G00,#ce [FALSE] RFALSE
       JE              G76,#1d [FALSE] RFALSE
       PRINT_RET       "You cannot enter in your condition."
L0001: JE              G78,#02,#00,#01 [TRUE] RFALSE
       JE              G78,#08,#0f,#0c [TRUE] RFALSE
       JE              G78,#06,#05,#07 [TRUE] RFALSE
       JE              G78,#88,#2a,#13 [TRUE] L0002
       JE              G78,#7e [FALSE] L0003
L0002: PRINT_RET       "All such attacks are vain in your condition."
L0003: JE              G78,#33,#23,#2b [TRUE] L0004
       JE              G78,#29,#17,#2f [TRUE] L0004
       JE              G78,#82,#1c,#59 [TRUE] L0004
       JE              G78,#6e,#86 [FALSE] L0005
L0004: PRINT_RET       "Even such an action is beyond your capabilities."
L0005: JE              G78,#87 [FALSE] L0006
       PRINT_RET       "Might as well. You've got an eternity."
L0006: JE              G78,#0e [FALSE] L0007
       PRINT_RET       "You need no light to guide you."
L0007: JE              G78,#09 [FALSE] L0008
       PRINT_RET       "You're dead! How can you think of your score?"
L0008: JE              G78,#5d [FALSE] L0009
       PRINT_RET       "Your hand passes through its object."
L0009: JE              G78,#04,#7f,#31 [FALSE] L0010
       PRINT_RET       "You have no possessions."
L0010: JE              G78,#03 [FALSE] L0011
       PRINT_RET       "You are dead."
L0011: JE              G78,#4f [FALSE] L0015
       PRINT           "The room looks strange and unearthly"
       GET_CHILD       G00 -> -(SP) [TRUE] L0012
       PRINT           "."
       JUMP            L0013
L0012: PRINT           " and objects appear indistinct."
L0013: NEW_LINE        
       TEST_ATTR       G00,#14 [TRUE] L0014
       PRINT           "Although there is no light, the room seems dimly
illuminated."
       NEW_LINE        
L0014: NEW_LINE        
       RFALSE          
L0015: JE              G78,#62 [FALSE] L0018
       JE              G00,#d4 [FALSE] L0017
       CLEAR_ATTR      "brass lantern",#07
       PUT_PROP        G6f,#11,#00
       STORE           G79,#00
       STORE           G48,#00
       STORE           G3e,#00
       JIN             "troll","The Troll Room" [FALSE] L0016
       STORE           G8d,#00
L0016: PRINT           "From the distance the sound of a lone trumpet is heard.
The room becomes very bright and you feel disembodied. In a moment, the
brightness fades and you find yourself rising as if from a long sleep, deep in
the woods. In the distance you can faintly hear a songbird and the sounds of
the forest."
       NEW_LINE        
       NEW_LINE        
       CALL            R0244 (#4e) -> -(SP)
       RET_POPPED      
L0017: PRINT_RET       "Your prayers are not heard."
L0018: PRINT           "You can't even do that."
       NEW_LINE        
       STORE           G6c,#00
       RET             #02

Routine R0401, 0 locals ()

       JZ              G90 [TRUE] L0001
       PRINT_RET       "There's not much lake left...."
L0001: JE              G78,#26 [FALSE] L0002
       PRINT_RET       "It's too wide to cross."
L0002: JE              G78,#22 [FALSE] RFALSE
       PRINT_RET       "You can't swim in this lake."

Routine R0402, 0 locals ()

       JE              G78,#22,#7d [FALSE] L0001
       PRINT_RET       "You can't swim in the stream."
L0001: JE              G78,#26 [FALSE] RFALSE
       PRINT_RET       "The other side is a sheer rock cliff."

Routine R0403, 0 locals ()

       JE              G78,#45 [TRUE] L0001
       JE              G78,#12 [FALSE] L0002
       JE              G76,#05 [FALSE] L0002
L0001: PRINT_RET       "You look before leaping, and realize that you would
never survive."
L0002: JE              G78,#26 [FALSE] L0003
       PRINT_RET       "It's too far to jump, and there's no bridge."
L0003: JE              G78,#81,#12 [FALSE] RFALSE
       JE              G77,#0d [FALSE] RFALSE
       PRINT           "The "
       PRINT_OBJ       G76
       PRINT           " drops out of sight into the chasm."
       NEW_LINE        
       CALL            R0116 (G76) -> -(SP)
       RET_POPPED      

Routine R0404, 0 locals ()

       JE              G78,#48 [FALSE] RFALSE
       PRINT_RET       "No."

Routine R0405, 0 locals ()

       JE              G78,#22 [FALSE] L0001
       CALL            R0247 (#15) -> -(SP)
       RTRUE           
L0001: PRINT_RET       "The gate is protected by an invisible force. It makes
your teeth ache to touch it."

Routine R0406, 0 locals ()

       JE              G78,#23,#2b [FALSE] L0001
       PRINT_RET       "The door won't budge."
L0001: JE              G78,#22 [FALSE] RFALSE
       CALL            R0247 (#1c) -> -(SP)
       RET_POPPED      

Routine R0407, 0 locals ()

       JE              G78,#2a [FALSE] RFALSE
       PRINT_RET       "Some paint chips away, revealing more paint."

Routine R0408, 0 locals ()

       JE              G78,#18 [FALSE] L0001
       PRINT_RET       "There is too much gas to blow away."
L0001: JE              G78,#75 [FALSE] RFALSE
       PRINT_RET       "It smells like coal gas in here."

Routine R0409, 6 locals (0000, 0000, 0000, 0000, 0000, 0000)

L0001: STORE           L01,#00
L0002: INC             L01
       JE              L01,L00 [FALSE] L0003
       STORE           L02,#01
       JUMP            L0007
L0003: LOADW           G03,L01 -> L04
       LOADW           L04,#00 -> L03
       TEST_ATTR       L03,#02 [TRUE] L0004
       JUMP            L0002
L0004: GET_PROP        L03,#11 -> -(SP)
       CALL            (SP)+ (#01) -> -(SP)
       JZ              (SP)+ [TRUE] L0005
       JUMP            L0002
L0005: CALL            R0414 (L04,L05) -> L02
       JZ              L02 [FALSE] L0006
       STORE           L02,#00
       JUMP            L0007
L0006: JE              L02,#02 [FALSE] L0002
       RANDOM          #03 -> -(SP)
       ADD             #01,(SP)+ -> L05
       JUMP            L0002
L0007: JZ              L02 [TRUE] RTRUE
       JZ              L05 [TRUE] RTRUE
       DEC             [L05]
       JZ              L05 [FALSE] L0001
       RTRUE           

Routine R0410, 6 locals (0000, 0000, 0000, 0000, 0000, 0000)

       LOADW           L00,#00 -> L03
L0001: INC_CHK         L04,L03 [FALSE] L0002
       JUMP            L0005
L0002: LOADW           L00,L04 -> L05
       JE              L05,#00 [FALSE] L0003
       PRINT_OBJ       L02
       JUMP            L0001
L0003: JE              L05,#01 [FALSE] L0004
       PRINT_OBJ       L01
       JUMP            L0001
L0004: PRINT_PADDR     L05
       JUMP            L0001
L0005: NEW_LINE        
       RTRUE           

Routine R0411, 2 locals (0001, 0000)

       SUB             #07,#02 -> -(SP)
       DIV             G97,(SP)+ -> -(SP)
       DIV             G01,(SP)+ -> -(SP)
       ADD             #02,(SP)+ -> L01
       JZ              L00 [TRUE] L0001
       GET_PROP        G6f,#07 -> -(SP)
       ADD             L01,(SP)+ -> -(SP)
       RET_POPPED      
L0001: RET             L01

Routine R0412, 4 locals (0000, 0000, 0000, 0000)

       LOADW           L00,#00 -> L01
       GET_PROP        L01,#07 -> L02
       JL              L02,#00 [TRUE] L0004
       JE              L01,#72 [FALSE] L0002
       JZ              G1e [TRUE] L0002
       JG              L02,#02 [FALSE] L0001
       STORE           L02,#02
L0001: STORE           G1e,#00
L0002: JZ              G77 [TRUE] L0004
       TEST_ATTR       G77,#1d [FALSE] L0004
       LOADW           L00,#01 -> -(SP)
       JE              (SP)+,G77 [FALSE] L0004
       LOADW           L00,#02 -> -(SP)
       SUB             L02,(SP)+ -> L03
       JL              L03,#01 [FALSE] L0003
       STORE           L03,#01
L0003: STORE           L02,L03
L0004: RET             L02

Routine R0413, 2 locals (0000, 0000)

       GET_CHILD       L00 -> L01 [TRUE] L0001
L0001: JZ              L01 [TRUE] RFALSE
L0002: JE              L01,#71,#da,#6e [TRUE] L0003
       JE              L01,#a9,#80 [FALSE] L0004
L0003: RET             L01
L0004: GET_SIBLING     L01 -> L01 [TRUE] L0002
       RFALSE          

Routine R0414, 12 locals (0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000,
                          0000, 0000, 0000)

       LOADW           L00,#00 -> L02
       LOADW           L00,#04 -> L03
       CLEAR_ATTR      G6f,#01
       TEST_ATTR       L02,#01 [FALSE] L0001
       PRINT           "The "
       PRINT_OBJ       L02
       PRINT           " slowly regains his feet."
       NEW_LINE        
       CLEAR_ATTR      L02,#01
       RTRUE           
L0001: CALL            R0412 (L00) -> -(SP)
       STORE           L05,(SP)+
       STORE           L07,#01
       CALL            R0411 -> L06
       JG              L06,#00 [FALSE] RTRUE
       CALL            R0411 (#00) -> L08
       CALL            R0413 (G6f) -> L04
       JL              L06,#00 [FALSE] L0002
       STORE           L0a,#03
       JUMP            L0013
L0002: JE              L06,#01 [FALSE] L0004
       JG              L05,#02 [FALSE] L0003
       STORE           L05,#03
L0003: SUB             L05,#01 -> -(SP)
       LOADW           G0a,(SP)+ -> L09
       JUMP            L0009
L0004: JE              L06,#02 [FALSE] L0006
       JG              L05,#03 [FALSE] L0005
       STORE           L05,#04
L0005: SUB             L05,#01 -> -(SP)
       LOADW           G09,(SP)+ -> L09
       JUMP            L0009
L0006: JG              L06,#02 [FALSE] L0009
       SUB             L05,L06 -> L05
       JL              L05,#ffff [FALSE] L0007
       STORE           L05,#fffe
       JUMP            L0008
L0007: JG              L05,#01 [FALSE] L0008
       STORE           L05,#02
L0008: ADD             L05,#02 -> -(SP)
       LOADW           G08,(SP)+ -> L09
L0009: RANDOM          #09 -> -(SP)
       SUB             (SP)+,#01 -> -(SP)
       LOADW           L09,(SP)+ -> L0a
       JZ              L01 [TRUE] L0011
       JE              L0a,#06 [FALSE] L0010
       STORE           L0a,#08
       JUMP            L0011
L0010: STORE           L0a,#09
L0011: JE              L0a,#06 [FALSE] L0012
       JZ              L04 [TRUE] L0012
       CALL            R0002 (#19) -> -(SP)
       JZ              (SP)+ [TRUE] L0012
       STORE           L0a,#07
L0012: SUB             L0a,#01 -> -(SP)
       LOADW           L03,(SP)+ -> -(SP)
       CALL            R0003 ((SP)+) -> -(SP)
       CALL            R0410 ((SP)+,G6f,L04) -> -(SP)
L0013: JE              L0a,#01 [TRUE] L0024
       JE              L0a,#08 [FALSE] L0014
       JUMP            L0024
L0014: JE              L0a,#02 [FALSE] L0015
       JUMP            L0024
L0015: JE              L0a,#03 [TRUE] L0016
       JE              L0a,#09 [FALSE] L0017
L0016: STORE           L06,#00
       JUMP            L0024
L0017: JE              L0a,#04 [FALSE] L0019
       DEC             L06
       JL              L06,#00 [FALSE] L0018
       STORE           L06,#00
L0018: JG              G85,#32 [FALSE] L0024
       SUB             G85,#0a -> G85
       JUMP            L0024
L0019: JE              L0a,#05 [FALSE] L0021
       SUB             L06,#02 -> L06
       JL              L06,#00 [FALSE] L0020
       STORE           L06,#00
L0020: JG              G85,#32 [FALSE] L0024
       SUB             G85,#14 -> G85
       JUMP            L0024
L0021: JE              L0a,#06 [FALSE] L0022
       SET_ATTR        G6f,#01
       JUMP            L0024
L0022: JE              L0a,#07 [FALSE] L0023
L0023: INSERT_OBJ      L04,G00
       CALL            R0413 (G6f) -> L0b
       JZ              L0b [TRUE] L0024
       PRINT           "Fortunately, you still have a "
       PRINT_OBJ       L0b
       PRINT           "."
       NEW_LINE        
L0024: CALL            R0416 (L06,L0a,L08) -> -(SP)
       RET_POPPED      

Routine R0415, 13 locals (0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000,
                          0000, 0000, 0000, 0000)

       LOADW           G03,#00 -> L0c
L0001: INC             L06
       JE              L06,L0c [FALSE] L0002
       JUMP            L0003
L0002: LOADW           G03,L06 -> L00
       LOADW           L00,#00 -> -(SP)
       JE              (SP)+,G76 [FALSE] L0001
L0003: SET_ATTR        G76,#02
       TEST_ATTR       G6f,#01 [FALSE] L0004
       PRINT           "You are still recovering from that last blow, so your
attack is ineffective."
       NEW_LINE        
       CLEAR_ATTR      G6f,#01
       RTRUE           
L0004: CALL            R0411 -> L04
       JL              L04,#01 [FALSE] L0005
       STORE           L04,#01
L0005: STORE           L07,L04
       LOADW           L00,#00 -> L01
       CALL            R0412 (L00) -> -(SP)
       STORE           L05,(SP)+
       STORE           L08,#01
       JZ              L08 [FALSE] L0007
       JE              G76,G6f [FALSE] L0006
       CALL            R0431 (S258) -> -(SP)
       RET_POPPED      
L0006: PRINT           "Attacking the "
       PRINT_OBJ       L01
       PRINT_RET       " is pointless."
L0007: CALL            R0413 (L01) -> L03
       JZ              L03 [TRUE] L0008
       JL              L05,#00 [FALSE] L0011
L0008: PRINT           "The "
       JZ              L03 [FALSE] L0009
       PRINT           "unarmed"
       JUMP            L0010
L0009: PRINT           "unconscious"
L0010: PRINT           " "
       PRINT_OBJ       L01
       PRINT           " cannot defend himself: He dies."
       NEW_LINE        
       STORE           L0a,#03
       JUMP            L0022
L0011: JE              L05,#01 [FALSE] L0013
       JG              L04,#02 [FALSE] L0012
       STORE           L04,#03
L0012: SUB             L04,#01 -> -(SP)
       LOADW           G0a,(SP)+ -> L09
       JUMP            L0018
L0013: JE              L05,#02 [FALSE] L0015
       JG              L04,#03 [FALSE] L0014
       STORE           L04,#04
L0014: SUB             L04,#01 -> -(SP)
       LOADW           G09,(SP)+ -> L09
       JUMP            L0018
L0015: JG              L05,#02 [FALSE] L0018
       SUB             L04,L05 -> L04
       JL              L04,#ffff [FALSE] L0016
       STORE           L04,#fffe
       JUMP            L0017
L0016: JG              L04,#01 [FALSE] L0017
       STORE           L04,#02
L0017: ADD             L04,#02 -> -(SP)
       LOADW           G08,(SP)+ -> L09
L0018: RANDOM          #09 -> -(SP)
       SUB             (SP)+,#01 -> -(SP)
       LOADW           L09,(SP)+ -> L0a
       JZ              L02 [TRUE] L0020
       JE              L0a,#06 [FALSE] L0019
       STORE           L0a,#08
       JUMP            L0020
L0019: STORE           L0a,#09
L0020: JE              L0a,#06 [FALSE] L0021
       JZ              L03 [TRUE] L0021
       RANDOM          #64 -> -(SP)
       JG              #19,(SP)+ [FALSE] L0021
       STORE           L0a,#07
L0021: SUB             L0a,#01 -> -(SP)
       LOADW           G07,(SP)+ -> -(SP)
       CALL            R0003 ((SP)+) -> -(SP)
       CALL            R0410 ((SP)+,G76,G77) -> -(SP)
L0022: JE              L0a,#01 [TRUE] L0031
       JE              L0a,#08 [FALSE] L0023
       JUMP            L0031
L0023: JE              L0a,#02 [FALSE] L0024
       SUB             #00,L05 -> L05
       JUMP            L0031
L0024: JE              L0a,#03 [TRUE] L0025
       JE              L0a,#09 [FALSE] L0026
L0025: STORE           L05,#00
       JUMP            L0031
L0026: JE              L0a,#04 [FALSE] L0027
       DEC             L05
       JL              L05,#00 [FALSE] L0031
       STORE           L05,#00
       JUMP            L0031
L0027: JE              L0a,#05 [FALSE] L0028
       SUB             L05,#02 -> L05
       JL              L05,#00 [FALSE] L0031
       STORE           L05,#00
       JUMP            L0031
L0028: JE              L0a,#06 [FALSE] L0029
       SET_ATTR        G76,#01
       JUMP            L0031
L0029: JE              L0a,#07 [FALSE] L0030
L0030: CLEAR_ATTR      L03,#0e
       SET_ATTR        L03,#1d
       INSERT_OBJ      L03,G00
       CALL            R0255 (L03) -> -(SP)
L0031: CALL            R0417 (G76,L05,L0a) -> -(SP)
       RET_POPPED      

Routine R0416, 3 locals (0000, 0000, 0000)

       JZ              L00 [FALSE] L0001
       PUSH            #d8f0
       JUMP            L0002
L0001: SUB             L00,L02 -> -(SP)
L0002: PUT_PROP        G6f,#07,(SP)+
       SUB             L00,L02 -> -(SP)
       JL              (SP)+,#00 [FALSE] L0003
       CALL            R0022 (#7fea,#1e) -> -(SP)
       STOREW          (SP)+,#00,#01
L0003: CALL            R0411 -> -(SP)
       JG              (SP)+,#00 [TRUE] L0004
       CALL            R0411 (#00) -> -(SP)
       SUB             #00,(SP)+ -> -(SP)
       ADD             #01,(SP)+ -> -(SP)
       PUT_PROP        G6f,#07,(SP)+
       CALL            R0431 (S259) -> -(SP)
       RFALSE          
L0004: RET             L01

Routine R0417, 3 locals (0000, 0000, 0000)

       PUT_PROP        L00,#07,L01
       JZ              L01 [FALSE] L0001
       CLEAR_ATTR      L00,#02
       PRINT           "Almost as soon as the "
       PRINT_OBJ       L00
       PRINT           " breathes his last breath, a cloud of sinister black
fog envelops him, and when the fog lifts, the carcass has disappeared."
       NEW_LINE        
       CALL            R0116 (L00) -> -(SP)
       GET_PROP        L00,#11 -> -(SP)
       CALL            (SP)+ (#02) -> -(SP)
       RET             L02
L0001: JE              L02,#02 [FALSE] L0002
       GET_PROP        L00,#11 -> -(SP)
       CALL            (SP)+ (#03) -> -(SP)
       RET             L02
L0002: RET             L02

Routine R0418, 3 locals (0000, 0000, 0000)

       GET_PROP        L00,#07 -> L01
       CALL            R0411 -> -(SP)
       SUB             L01,(SP)+ -> L02
       JG              L02,#03 [FALSE] L0001
       RANDOM          #64 -> -(SP)
       JG              #5a,(SP)+ [TRUE] RTRUE
       RFALSE          
L0001: JG              L02,#00 [FALSE] L0002
       RANDOM          #64 -> -(SP)
       JG              #4b,(SP)+ [TRUE] RTRUE
       RFALSE          
L0002: JZ              L02 [FALSE] L0003
       RANDOM          #64 -> -(SP)
       JG              #32,(SP)+ [TRUE] RTRUE
       RFALSE          
L0003: JG              L01,#01 [FALSE] L0004
       RANDOM          #64 -> -(SP)
       JG              #19,(SP)+ [TRUE] RTRUE
       RFALSE          
L0004: RANDOM          #64 -> -(SP)
       JG              #0a,(SP)+ [TRUE] RTRUE
       RFALSE          

Routine R0419, 1 local (0000)

       GET_PROP        G6f,#07 -> L00
       JG              L00,#00 [FALSE] L0001
       STORE           L00,#00
       PUT_PROP        G6f,#07,L00
       JUMP            L0002
L0001: JL              L00,#00 [FALSE] L0002
       INC             L00
       PUT_PROP        G6f,#07,L00
L0002: JL              L00,#00 [FALSE] L0004
       JL              G85,G86 [FALSE] L0003
       ADD             G85,#0a -> G85
L0003: CALL            R0022 (#7fea,#1e) -> -(SP)
       STOREW          (SP)+,#00,#01
       RTRUE           
L0004: STORE           G85,G86
       CALL            R0023 (#7fea) -> -(SP)
       STOREW          (SP)+,#00,#00
       RTRUE           

Routine R0420, 6 locals (0000, 0000, 0000, 0000, 0000, 0000)

       LOADW           G03,#00 -> L01
       JZ              G3e [FALSE] RFALSE
       STORE           L02,#00
L0001: INC             L02
       JE              L02,L01 [FALSE] L0002
       JUMP            L0010
L0002: LOADW           G03,L02 -> L03
       LOADW           L03,#00 -> L04
       JIN             L04,G00 [FALSE] L0007
       TEST_ATTR       L04,#07 [TRUE] L0007
       JE              L04,#72 [FALSE] L0003
       JZ              G1e [TRUE] L0003
       STORE           G1e,#00
       JUMP            L0001
L0003: GET_PROP        L04,#07 -> -(SP)
       JL              (SP)+,#00 [FALSE] L0005
       LOADW           L03,#03 -> L05
       JZ              L05 [TRUE] L0004
       RANDOM          #64 -> -(SP)
       JG              L05,(SP)+ [FALSE] L0004
       STOREW          L03,#03,#00
       CALL            R0421 (L04) -> -(SP)
       JUMP            L0001
L0004: ADD             L05,#19 -> -(SP)
       STOREW          L03,#03,(SP)+
       JUMP            L0001
L0005: TEST_ATTR       L04,#02 [TRUE] L0006
       GET_PROP        L04,#11 -> -(SP)
       CALL            (SP)+ (#05) -> -(SP)
       JZ              (SP)+ [TRUE] L0001
L0006: STORE           L00,#01
       JUMP            L0001
L0007: TEST_ATTR       L04,#02 [FALSE] L0008
       GET_PROP        L04,#11 -> -(SP)
       CALL            (SP)+ (#01) -> -(SP)
L0008: JE              L04,#72 [FALSE] L0009
       STORE           G1e,#00
L0009: CLEAR_ATTR      G6f,#01
       CLEAR_ATTR      L04,#01
       CLEAR_ATTR      L04,#02
       CALL            R0421 (L04) -> -(SP)
       JUMP            L0001
L0010: JZ              L00 [TRUE] RFALSE
       CALL            R0409 (L01) -> -(SP)
       RET_POPPED      

Routine R0421, 2 locals (0000, 0000)

       GET_PROP        L00,#07 -> L01
       JL              L01,#00 [FALSE] RTRUE
       SUB             #00,L01 -> -(SP)
       PUT_PROP        L00,#07,(SP)+
       GET_PROP        L00,#11 -> -(SP)
       CALL            (SP)+ (#04) -> -(SP)
       RTRUE           

Routine R0422, 6 locals (0000, 0000, 0000, 0000, 0000, 0000)

       CALL            R0023 (#807c) -> L00
       GET_PROP        "sword",#0c -> L01
       JIN             "sword","cretin" [FALSE] L0008
       CALL            R0423 (G00) -> -(SP)
       JZ              (SP)+ [TRUE] L0001
       STORE           L02,#02
       JUMP            L0004
L0001: STORE           L03,#00
L0002: GET_NEXT_PROP   G00,L03 -> L03
       JZ              L03 [FALSE] L0003
       JUMP            L0004
L0003: JL              L03,G98 [TRUE] L0002
       GET_PROP_ADDR   G00,L03 -> L04
       GET_PROP_LEN    L04 -> L05
       JE              L05,#01,#04,#05 [FALSE] L0002
       LOADB           L04,#00 -> -(SP)
       CALL            R0423 ((SP)+) -> -(SP)
       JZ              (SP)+ [TRUE] L0002
       STORE           L02,#01
L0004: JE              L02,L01 [TRUE] RFALSE
       JE              L02,#02 [FALSE] L0005
       PRINT           "Your sword has begun to glow very brightly."
       NEW_LINE        
       JUMP            L0007
L0005: JE              L02,#01 [FALSE] L0006
       PRINT           "Your sword is glowing with a faint blue glow."
       NEW_LINE        
       JUMP            L0007
L0006: JZ              L02 [FALSE] L0007
       PRINT           "Your sword is no longer glowing."
       NEW_LINE        
L0007: PUT_PROP        "sword",#0c,L02
       RTRUE           
L0008: STOREW          L00,#00,#00
       RFALSE          

Routine R0423, 2 locals (0000, 0000)

       GET_CHILD       L00 -> L01 [TRUE] L0001
L0001: JZ              L01 [TRUE] RFALSE
       TEST_ATTR       L01,#1e [FALSE] L0002
       TEST_ATTR       L01,#07 [FALSE] RTRUE
L0002: GET_SIBLING     L01 -> L01 [TRUE] L0001
       RFALSE          

Routine R0424, 5 locals (0000, 0000, 0000, 0000, 0000)

       GET_PARENT      "thief" -> L00
L0001: TEST_ATTR       "thief",#07 [TRUE] L0002
       PUSH            #01
       JUMP            L0003
L0002: PUSH            #00
L0003: STORE           L02,(SP)+
       JZ              L02 [TRUE] L0004
       GET_PARENT      "thief" -> L00
L0004: JE              L00,#be [FALSE] L0006
       JE              L00,G00 [TRUE] L0006
       JZ              L02 [TRUE] L0005
       CALL            R0340 -> -(SP)
       STORE           L02,#00
L0005: CALL            R0341 (#be) -> -(SP)
       JUMP            L0011
L0006: JE              L00,G00 [FALSE] L0007
       TEST_ATTR       L00,#14 [TRUE] L0007
       JIN             "troll",G00 [TRUE] L0007
       CALL            R0338 (L02) -> -(SP)
       JZ              (SP)+ [FALSE] RTRUE
       TEST_ATTR       "thief",#07 [FALSE] L0011
       STORE           L02,#00
       JUMP            L0011
L0007: JIN             "thief",L00 [FALSE] L0008
       TEST_ATTR       "thief",#07 [TRUE] L0008
       SET_ATTR        "thief",#07
       STORE           L02,#00
L0008: TEST_ATTR       L00,#03 [FALSE] L0011
       CALL            R0428 (L00,#72,#4b) -> -(SP)
       TEST_ATTR       L00,#05 [FALSE] L0009
       TEST_ATTR       G00,#05 [FALSE] L0009
       CALL            R0342 (L00) -> -(SP)
       JUMP            L0010
L0009: CALL            R0427 (L00) -> -(SP)
L0010: STORE           L04,(SP)+
L0011: JZ              L03 [FALSE] L0012
       PUSH            #01
       JUMP            L0013
L0012: PUSH            #00
L0013: STORE           L03,(SP)+
       JZ              L03 [TRUE] L0017
       JZ              L02 [FALSE] L0017
       CALL            R0426 -> -(SP)
L0014: JZ              L00 [TRUE] L0015
       GET_SIBLING     L00 -> L00 [FALSE] L0015
       JUMP            L0016
L0015: GET_CHILD       #52 -> L00 [TRUE] L0016
L0016: TEST_ATTR       L00,#09 [TRUE] L0014
       TEST_ATTR       L00,#06 [FALSE] L0014
       INSERT_OBJ      "thief",L00
       CLEAR_ATTR      "thief",#02
       SET_ATTR        "thief",#07
       STORE           G1f,#00
       JUMP            L0001
L0017: JE              L00,#be [TRUE] L0018
       CALL            R0425 (L00) -> -(SP)
       RET             L04
L0018: RET             L04

Routine R0425, 4 locals (0000, 0000, 0000, 0000)

       GET_CHILD       "thief" -> L01 [TRUE] L0001
L0001: JZ              L01 [FALSE] L0002
       RET             L03
L0002: GET_SIBLING     L01 -> L02 [TRUE] L0003
L0003: JE              L01,#71,#73 [FALSE] L0004
       JUMP            L0005
L0004: GET_PROP        L01,#0c -> -(SP)
       JZ              (SP)+ [FALSE] L0005
       CALL            R0002 (#1e) -> -(SP)
       JZ              (SP)+ [TRUE] L0005
       CLEAR_ATTR      L01,#07
       INSERT_OBJ      L01,L00
       JZ              L03 [FALSE] L0005
       JE              L00,G00 [FALSE] L0005
       PRINT           "The robber, rummaging through his bag, dropped a few
items he found valueless."
       NEW_LINE        
       STORE           L03,#01
L0005: STORE           L01,L02
       JUMP            L0001

Routine R0426, 0 locals ()

       GET_PARENT      "thief" -> -(SP)
       JIN             "stiletto",(SP)+ [FALSE] RFALSE
       SET_ATTR        "stiletto",#0e
       INSERT_OBJ      "stiletto","thief"
       RTRUE           

Routine R0427, 3 locals (0000, 0000, 0000)

       GET_CHILD       L00 -> L01 [TRUE] L0001
L0001: JZ              L01 [TRUE] RFALSE
       GET_SIBLING     L01 -> L02 [TRUE] L0002
L0002: GET_PROP        L01,#0c -> -(SP)
       JZ              (SP)+ [FALSE] L0005
       TEST_ATTR       L01,#11 [FALSE] L0005
       TEST_ATTR       L01,#09 [TRUE] L0005
       TEST_ATTR       L01,#07 [TRUE] L0005
       JE              L01,#71 [TRUE] L0003
       CALL            R0002 (#0a) -> -(SP)
       JZ              (SP)+ [TRUE] L0005
L0003: INSERT_OBJ      L01,"thief"
       SET_ATTR        L01,#03
       SET_ATTR        L01,#07
       JE              L01,#81 [FALSE] L0004
       STORE           G93,#00
L0004: JE              L00,G00 [FALSE] RFALSE
       PRINT           "You suddenly notice that the "
       PRINT_OBJ       L01
       PRINT_RET       " vanished."
L0005: STORE           L01,L02
       JUMP            L0001

Routine R0428, 6 locals (0000, 0000, 0000, 0000, 0000, 0000)

       GET_CHILD       L00 -> L04 [TRUE] L0001
L0001: JZ              L04 [FALSE] L0002
       RET             L05
L0002: GET_SIBLING     L04 -> L03 [TRUE] L0003
L0003: TEST_ATTR       L04,#07 [TRUE] L0006
       TEST_ATTR       L04,#09 [TRUE] L0006
       GET_PROP        L04,#0c -> -(SP)
       JG              (SP)+,#00 [FALSE] L0006
       JZ              L02 [TRUE] L0004
       RANDOM          #64 -> -(SP)
       JG              L02,(SP)+ [FALSE] L0006
L0004: INSERT_OBJ      L04,L01
       SET_ATTR        L04,#03
       JE              L01,L01 [FALSE] L0005
       SET_ATTR        L04,#07
L0005: STORE           L05,#01
L0006: STORE           L04,L03
       JUMP            L0001

Routine R0429, 4 locals (0000, 0000, 0000, 0000)
    Action routine for:
        "diagno"

       CALL            R0411 (#00) -> L00
       GET_PROP        G6f,#07 -> L01
       ADD             L00,L01 -> L02
       CALL            R0023 (#7fea) -> -(SP)
       LOADW           (SP)+,#00 -> -(SP)
       JZ              (SP)+ [FALSE] L0001
       STORE           L01,#00
       JUMP            L0002
L0001: SUB             #00,L01 -> L01
L0002: JZ              L01 [FALSE] L0003
       PRINT           "You are in perfect health."
       JUMP            L0007
L0003: PRINT           "You have "
       JE              L01,#01 [FALSE] L0004
       PRINT           "a light wound,"
       JUMP            L0007
L0004: JE              L01,#02 [FALSE] L0005
       PRINT           "a serious wound,"
       JUMP            L0007
L0005: JE              L01,#03 [FALSE] L0006
       PRINT           "several wounds,"
       JUMP            L0007
L0006: JG              L01,#03 [FALSE] L0007
       PRINT           "serious wounds,"
L0007: JZ              L01 [TRUE] L0008
       PRINT           " which will be cured after "
       SUB             L01,#01 -> -(SP)
       MUL             #1e,(SP)+ -> L03
       CALL            R0023 (#7fea) -> -(SP)
       LOADW           (SP)+,#01 -> -(SP)
       ADD             L03,(SP)+ -> -(SP)
       PRINT_NUM       (SP)+
       PRINT           " moves."
L0008: NEW_LINE        
       PRINT           "You can "
       JZ              L02 [FALSE] L0009
       PRINT           "expect death soon"
       JUMP            L0013
L0009: JE              L02,#01 [FALSE] L0010
       PRINT           "be killed by one more light wound"
       JUMP            L0013
L0010: JE              L02,#02 [FALSE] L0011
       PRINT           "be killed by a serious wound"
       JUMP            L0013
L0011: JE              L02,#03 [FALSE] L0012
       PRINT           "survive one serious wound"
       JUMP            L0013
L0012: JG              L02,#03 [FALSE] L0013
       PRINT           "strong enough to take several wounds."
L0013: PRINT           "."
       NEW_LINE        
       JZ              G3d [TRUE] RFALSE
       PRINT           "You have been killed "
       JE              G3d,#01 [FALSE] L0014
       PRINT           "once"
       JUMP            L0015
L0014: PRINT           "twice"
L0015: PRINT_RET       "."

Routine R0430, 1 local (0001)
    Action routine for:
        "score"

       PRINT           "Your score is "
       PRINT_NUM       G01
       PRINT           " (total of 350 points), in "
       PRINT_NUM       G02
       JE              G02,#01 [FALSE] L0001
       PRINT           " move."
       JUMP            L0002
L0001: PRINT           " moves."
L0002: NEW_LINE        
       PRINT           "This gives you the rank of "
       JE              G01,#015e [FALSE] L0003
       PRINT           "Master Adventurer"
       JUMP            L0010
L0003: JG              G01,#014a [FALSE] L0004
       PRINT           "Wizard"
       JUMP            L0010
L0004: JG              G01,#012c [FALSE] L0005
       PRINT           "Master"
       JUMP            L0010
L0005: JG              G01,#c8 [FALSE] L0006
       PRINT           "Adventurer"
       JUMP            L0010
L0006: JG              G01,#64 [FALSE] L0007
       PRINT           "Junior Adventurer"
       JUMP            L0010
L0007: JG              G01,#32 [FALSE] L0008
       PRINT           "Novice Adventurer"
       JUMP            L0010
L0008: JG              G01,#19 [FALSE] L0009
       PRINT           "Amateur Adventurer"
       JUMP            L0010
L0009: PRINT           "Beginner"
L0010: PRINT           "."
       NEW_LINE        
       RET             G01

Routine R0431, 2 locals (0000, 0000)

       JZ              G3e [TRUE] L0001
       PRINT           "
It takes a talented person to be killed while already dead. YOU are such a
talent. Unfortunately, it takes a talented person to deal with it. I am not
such a talent. Sorry."
       NEW_LINE        
       CALL            R0236 -> -(SP)
L0001: PRINT_PADDR     L00
       NEW_LINE        
       JZ              G3c [FALSE] L0002
       PRINT           "Bad luck, huh?"
       NEW_LINE        
L0002: CALL            R0234 (#fff6) -> -(SP)
       PRINT           " 
   ****  You have died  **** 

"
       GET_PARENT      G6f -> -(SP)
       TEST_ATTR       (SP)+,#1b [FALSE] L0003
       INSERT_OBJ      G6f,G00
L0003: JL              G3d,#02 [TRUE] L0004
       PRINT           "You clearly are a suicidal maniac. We don't allow
psychotics in the cave, since they may harm other adventurers. Your remains
will be installed in the Land of the Living Dead, where your fellow adventurers
may gloat over them."
       NEW_LINE        
       CALL            R0236 -> -(SP)
       RET_POPPED      
L0004: INC             G3d
       INSERT_OBJ      G6f,G00
       TEST_ATTR       "Altar",#03 [FALSE] L0005
       PRINT           "As you take your last breath, you feel relieved of your
burdens. The feeling passes as you find yourself before the gates of Hell,
where the spirits jeer at you and deny you entry. Your senses are disturbed.
The objects in the dungeon appear indistinct, bleached of color, even unreal."
       NEW_LINE        
       NEW_LINE        
       STORE           G3e,#01
       STORE           G8d,#01
       STORE           G79,#01
       STORE           G48,#01
       PUT_PROP        G6f,#11,#7ad5
       CALL            R0244 (#e8) -> -(SP)
       JUMP            L0006
L0005: PRINT           "Now, let's take a look here... Well, you probably
deserve another chance. I can't quite fix you up completely, but you can't have
everything."
       NEW_LINE        
       NEW_LINE        
       CALL            R0244 (#4e) -> -(SP)
L0006: CLEAR_ATTR      "trap door",#03
       STORE           G6c,#00
       CALL            R0432 -> -(SP)
       CALL            R0433 -> -(SP)
       RET_POPPED      

Routine R0432, 4 locals (0000, 0000, 0000, 0000)

       JIN             "brass lantern",G6f [FALSE] L0001
       INSERT_OBJ      "brass lantern","Living Room"
L0001: JIN             "gold coffin",G6f [FALSE] L0002
       INSERT_OBJ      "gold coffin","Egyptian Room"
L0002: PUT_PROP        "sword",#0c,#00
       GET_CHILD       G6f -> L02 [TRUE] L0003
L0003: LOADW           G87,#00 -> L03
L0004: STORE           L01,L02
       JZ              L01 [TRUE] RTRUE
       GET_SIBLING     L01 -> L02 [TRUE] L0005
L0005: GET_PROP        L01,#0c -> -(SP)
       JG              (SP)+,#00 [FALSE] L0010
L0006: JZ              L00 [FALSE] L0007
       GET_CHILD       #52 -> L00 [TRUE] L0007
L0007: TEST_ATTR       L00,#06 [FALSE] L0008
       TEST_ATTR       L00,#14 [TRUE] L0008
       RANDOM          #64 -> -(SP)
       JG              #32,(SP)+ [FALSE] L0008
       INSERT_OBJ      L01,L00
       JUMP            L0004
L0008: GET_SIBLING     L00 -> L00 [TRUE] L0009
L0009: JUMP            L0006
L0010: RANDOM          L03 -> -(SP)
       LOADW           G87,(SP)+ -> -(SP)
       INSERT_OBJ      L01,(SP)+
       JUMP            L0004

Routine R0433, 0 locals ()

       CALL            R0023 (#5c3e) -> -(SP)
       STOREW          (SP)+,#00,#00
       CALL            R0023 (#5c6d) -> -(SP)
       STOREW          (SP)+,#00,#00
       CALL            R0023 (#649f) -> -(SP)
       STOREW          (SP)+,#00,#00
       CALL            R0023 (#6f55) -> -(SP)
       STOREW          (SP)+,#00,#00
       CALL            R0023 (#6f6a) -> -(SP)
       STOREW          (SP)+,#00,#00
       CALL            R0023 (#807c) -> -(SP)
       STOREW          (SP)+,#00,#00
       CALL            R0023 (#7954) -> -(SP)
       STOREW          (SP)+,#00,#00
       CALL            R0023 (#6f46) -> -(SP)
       STOREW          (SP)+,#00,#00
       CLEAR_ATTR      "matchbook",#14
       RTRUE           

Routine R0434, 0 locals ()

       CALL            R0436 (#a5,S384) -> -(SP)
       RET_POPPED      

Routine R0435, 0 locals ()

       CALL            R0436 (#65,S385) -> -(SP)
       RET_POPPED      

Routine R0436, 2 locals (0000, 0000)

       JE              G78,#23,#2b [FALSE] L0001
       PRINT           "The "
       PRINT_PADDR     L01
       PRINT_RET       " are safely inside; there's no need to do that."
L0001: JE              G78,#38,#39 [FALSE] L0002
       PRINT           "There are lots of "
       PRINT_PADDR     L01
       PRINT_RET       " in there."
L0002: JE              G78,#12 [FALSE] RFALSE
       JE              G77,L00 [FALSE] RFALSE
       PRINT           "Don't be silly. It wouldn't be a "
       PRINT_OBJ       L00
       PRINT_RET       " anymore."

Routine R0437, 0 locals ()

       JE              G78,#39,#23,#2b [FALSE] L0001
       PRINT_RET       "You can't do that."
L0001: JE              G78,#38 [FALSE] RFALSE
       PRINT           "It looks pretty much like a "
       PRINT_OBJ       G76
       PRINT_RET       "."

Routine R0438, 0 locals ()

       JE              G78,#33 [FALSE] RFALSE
       CALL            R0116 (G76) -> -(SP)
       PRINT_RET       "What the heck! You won't make friends this way, but
nobody around here is too friendly anyhow. Gulp!"

Routine R0439, 0 locals ()

       JE              G78,#58,#5d [FALSE] L0001
       PRINT_RET       "The chain is secure."
L0001: JE              G78,#54,#69 [FALSE] L0002
       PRINT_RET       "Perhaps you should do that to the basket."
L0002: JE              G78,#38 [FALSE] RFALSE
       PRINT_RET       "The chain secures a basket within the shaft."

Routine R0440, 1 local (0000)

       JE              L00,#02 [FALSE] RFALSE
       JIN             "troll",G00 [FALSE] RFALSE
       CALL            R0255 (#d9) -> -(SP)
       RET_POPPED      

[End of code]

[Start of text]

S001: "Lying in one corner of the room is a beautifully carved crystal skull.
It appears to be grinning at you rather nastily."
S002: "From the chain is suspended a basket."
S003: "At the end of the chain is a basket."
S004: "A hot pepper sandwich is here."
S005: "On the ground is a red hot bell."
S006: "On the altar is a large black book, open to page 569."
S007: "Commandment #12592

Oh ye who go about saying unto each:  "Hello sailor":
Dost thou know the magnitude of thy sin before the gods?
Yea, verily, thou shalt be ground between two stones.
Shall the angry gods cast thy body into the whirlpool?
Surely, thy eye shall be put out with a sharp stick!
Even unto the ends of the earth shalt thou wander and
Unto the land of the dead shalt thou be sent at last.
Surely thou shalt repent of thy cunning."
S008: "An ornamented sceptre, tapering to a sharp point, is here."
S009: "A sceptre, possibly that of ancient Egypt itself, is in the coffin. The
sceptre is ornamented with colored enamel, and tapers to a sharp point."
S010: "On the table is an elongated brown sack, smelling of hot peppers."
S011: "There is a silver chalice, intricately engraved, here."
S012: "On the shore lies Poseidon's own crystal trident."
S013: "A bottle is sitting on the table."
S014: "The solid-gold coffin used for the burial of Ramses II is here."
S015: "There is an enormous diamond (perfectly cut) here."
S016: "There is an exquisite jade figurine here."
S017: "On a table is a nasty-looking knife."
S018: "The deceased adventurer's useless lantern is here."
S019: "An old leather bag, bulging with coins, is here."
S020: "A battery-powered brass lantern is on the trophy case."
S021: "There is a brass lantern (battery-powered) here."
S022: "A small leaflet is on the ground."
S023: ""WELCOME TO ZORK!

ZORK is a game of adventure, danger, and low cunning. In it you will explore
some of the most amazing territory ever seen by mortals. No computer should be
without one!"
"
S024: "There is a matchbook whose cover says "Visit Beautiful FCD#3" here."
S025: "
(Close cover before striking)

YOU too can make BIG MONEY in the exciting field of PAPER SHUFFLING!

Mr. Anderson of Muddle, Mass. says: "Before I took this course I was a lowly
bit twiddler. Now with what I learned at GUE Tech I feel really important and
can obfuscate and confuse with the best."

Dr. Blank had this to say: "Ten short days ago all I could look forward to was
a dead-end job as a doctor. Now I have a promising future and make really big
Zorkmids."

GUE Tech can't promise these fantastic results to everyone. But when you earn
your degree from GUE Tech, your future will be brighter.
"
S026: "Fortunately, there is still one chance for you to be a vandal, for on
the far wall is a painting of unparalleled beauty."
S027: "A painting by a neglected genius is here."
S028: "On the two ends of the altar are burning candles."
S029: "On the ground is a pile of leaves."
S030: "There is a folded pile of plastic here which has a small valve
attached."
S031: "On the ground is a large platinum bar."
S032: "At the end of the rainbow is a pot of gold."
S033: "The prayer is inscribed in an ancient script, rarely used today. It
seems to be a philippic against small insects, absent-mindedness, and the
picking up and dropping of small objects. The final verse consigns trespassers
to the land of the dead. All evidence indicates that the beliefs of the ancient
Zorkers were obscure."
S034: "There is a red buoy here (probably a warning)."
S035: "A large coil of rope is lying in the corner."
S036: "Beside the skeleton is a rusty knife."
S037: "The engravings translate to "This space intentionally left blank.""
S038: "Above the trophy case hangs an elvish sword of great antiquity."
S039: "In the trophy case is an ancient parchment which appears to be a map."
S040: "The map shows a forest with three clearings. The largest clearing
contains a house. Three paths leave the large clearing. One of these paths,
leading southwest, is marked "To Stone Barrow"."
S041: "   !!!!  FROBOZZ MAGIC BOAT COMPANY  !!!!

Hello, Sailor!

Instructions for use:

   To get into a body of water, say "Launch".
   To get to shore, say "Land" or the direction in which you want to maneuver
the boat.

Warranty:

  This boat is guaranteed against all defects for a period of 76 milliseconds
from date of purchase or until first used, whichever comes first.

Warning:
   This boat is made of thin plastic.
   Good Luck!
"
S042: "There is a suspicious-looking individual, holding a large bag, leaning
against one wall. He is armed with a deadly stiletto."
S043: "Sitting on the pedestal is a flaming torch, made of ivory."
S044: "Some guidebooks entitled "Flood Control Dam #3" are on the reception
desk."
S045: "" Flood Control Dam #3

FCD#3 was constructed in year 783 of the Great Underground Empire to harness
the mighty Frigid River. This work was supported by a grant of 37 million
zorkmids from your omnipotent local tyrant Lord Dimwit Flathead the Excessive.
This impressive structure is composed of 370,000 cubic feet of concrete, is 256
feet tall at the center, and 193 feet wide at the top. The lake created behind
the dam has a volume of 1.7 billion cubic feet, an area of 12 million square
feet, and a shore line of 36 thousand feet.

We will now point out some of the more interesting features of FCD#3 as we
conduct you on a guided tour of the facilities:
        1) You start your tour here in the Dam Lobby. You will notice on your
right that...."
S046: "A nasty-looking troll, brandishing a bloody axe, blocks all passages out
of the room."
S047: "Lying half buried in the mud is an old trunk, bulging with jewels."
S048: "There is an old trunk here, bulging with assorted jewels."
S049: "There is an object which looks like a tube of toothpaste here."
S050: "---> Frobozz Magic Gunk Company <---
   All-Purpose Gunk"
S051: "There are old engravings on the walls here."
S052: "The engravings were incised in the living rock of the cave wall by an
unknown hand. They depict, in symbolic form, the beliefs of the ancient
Zorkers. Skillfully interwoven with the bas reliefs are excerpts illustrating
the major religious tenets of that time. Unfortunately, a later age seems to
have considered them blasphemous and just as skillfully excised them."
S053: "Loosely attached to a wall is a small piece of paper."
S054: "
Congratulations!

You are the privileged owner of ZORK I: The Great Underground Empire, a
self-contained and self-maintaining universe. If used and maintained in
accordance with normal operating practices for small universes, ZORK will
provide many months of trouble-free operation.

"
S055: "Beside you on the branch is a small bird's nest."
S056: "In the bird's nest is a large egg encrusted with precious jewels,
apparently scavenged by a childless songbird. The egg is covered with fine gold
inlay, and ornamented in lapis lazuli and mother-of-pearl. Unlike most eggs,
this one is hinged and closed with a delicate looking clasp. The egg appears
extremely fragile."
S057: "There is a somewhat ruined egg here."
S058: "There is a golden clockwork canary nestled in the egg. It has ruby eyes
and a silver beak. Through a crystal window below its left wing you can see
intricate machinery inside. It appears to have wound down."
S059: "There is a golden clockwork canary nestled in the egg. It seems to have
recently had a bad experience. The mountings for its jewel-like eyes are empty,
and its silver beak is crumpled. Through a cracked crystal window below its
left wing you can see the remains of intricate machinery. It is not clear what
result winding it would have, as the mainspring seems sprung."
S060: "The door is boarded and you can't remove the boards."
S061: "You are standing in front of a massive barrow of stone. In the east face
is a huge stone door which is open. You cannot see into the dark of the tomb."
S062: "You are facing the north side of a white house. There is no door here,
and all the windows are boarded up. To the north a narrow path winds through
the trees."
S063: "The windows are all boarded."
S064: "You are facing the south side of a white house. There is no door here,
and all the windows are boarded."
S065: "This is a forest, with trees in all directions. To the east, there
appears to be sunlight."
S066: "There is no tree here suitable for climbing."
S067: "You would need a machete to go further west."
S068: "This is a dimly lit forest, with large trees all around."
S069: "The forest becomes impenetrable to the north."
S070: "The forest thins out, revealing impassable mountains."
S071: "The mountains are impassable."
S072: "The rank undergrowth prevents eastward movement."
S073: "Storm-tossed trees block your way."
S074: "This is a path winding through a dimly lit forest. The path heads
north-south here. One particularly large tree with some low branches stands at
the edge of the path."
S075: "You cannot climb any higher."
S076: "You are in a small clearing in a well marked forest path that extends to
the east and west."
S077: "Only Santa Claus climbs down chimneys."
S078: "This is the attic. The only exit is a stairway leading down."
S079: "The door is nailed shut."
S080: "You try to ascend the ramp, but it is impossible, and you slide back
down."
S081: "This is a small room with passages to the east and south and a
forbidding hole leading west. Bloodstains and deep scratches (perhaps made by
an axe) mar the walls."
S082: "The troll fends you off with a menacing gesture."
S083: "You are on the east edge of a chasm, the bottom of which cannot be seen.
A narrow passage goes north, and the path you are on continues to the east."
S084: "The chasm probably leads straight to the infernal regions."
S085: "This is an art gallery. Most of the paintings have been stolen by
vandals with exceptional taste. The vandals left through either the north or
west exits."
S086: "This appears to have been an artist's studio. The walls and floors are
splattered with paints of 69 different colors. Strangely enough, nothing of
value is hanging here. At the south end of the room is an open door (also
covered with paint). A dark and narrow chimney leads up from a fireplace;
although you might be able to get up it, it seems unlikely you could get back
down."
S087: "This is part of a maze of twisty little passages, all alike."
S088: "You have come to a dead end in the maze."
S089: "This is part of a maze of twisty little passages, all alike. A skeleton,
probably the remains of a luckless adventurer, lies here."
S090: "The grating is closed."
S091: "The east wall is solid rock."
S092: "The cyclops doesn't look like he'll let you past."
S093: "This is a long passage. To the west is one entrance. On the east there
is an old wooden door, with a large opening in it (about cyclops sized)."
S094: "This is a large room, whose east wall is solid granite. A number of
discarded bags, which crumble at your touch, are scattered about on the floor.
There is an exit down a staircase."
S095: "You would drown."
S096: "The dam blocks your way."
S097: "You are standing on a path beside a gently flowing stream. The path
follows the stream, which flows from west to east."
S098: "The stream emerges from a spot too small for you to enter."
S099: "You are on the gently flowing stream. The upstream route is too narrow
to navigate, and the downstream route is invisible due to twisting walls. There
is a narrow beach to land on."
S100: "The channel is too narrow."
S101: "This is a tiny cave with entrances west and north, and a staircase
leading down."
S102: "This is a tiny cave with entrances west and north, and a dark,
forbidding staircase leading down."
S103: "This is a cold and damp corridor where a long east-west passageway turns
into a southward path."
S104: "This is a long and narrow corridor where a long north-south passageway
briefly narrows even further."
S105: "This is a winding passage. It seems that there are only exits on the
east and north."
S106: "This is an ancient room, long under water. There is an exit to the south
and a staircase leading up."
S107: "This is a narrow east-west passageway. There is a narrow stairway
leading down at the north end of the room."
S108: "This is a circular stone room with passages in all directions. Several
of them have unfortunately been blocked by cave-ins."
S109: "This cave has exits to the west and east, and narrows to a crack toward
the south. The earth is particularly damp here."
S110: "It is too narrow for most insects."
S111: "This is a high north-south passage, which forks to the northeast."
S112: "A chasm runs southwest to northeast and the path follows it. You are on
the south side of the chasm, where a crack opens into a passage."
S113: "Are you out of your mind?"
S114: "Some invisible force prevents you from passing through the gate."
S115: "You have entered the Land of the Living Dead. Thousands of lost souls
can be heard weeping and moaning. In the corner are stacked the remains of
dozens of previous adventurers less fortunate than yourself. A passage exits to
the north."
S116: "You have entered a low cave with passages leading northwest and east."
S117: "This is a room which looks like an Egyptian tomb. There is an ascending
staircase to the west."
S118: "You cannot go down without fracturing many bones."
S119: "You cannot reach the rope."
S120: "This is the north end of a large temple. On the east wall is an ancient
inscription, probably a prayer in a long-forgotten language. Below the prayer
is a staircase leading down. The west wall is solid granite. The exit to the
north end of the room is through huge marble pillars."
S121: "This is the south end of a large temple. In front of you is what appears
to be an altar. In one corner is a small hole in the floor which leads into
darkness. You probably could not get back up it."
S122: "You haven't a prayer of getting the coffin down there."
S123: "This room appears to have been the waiting room for groups touring the
dam. There are open doorways here to the north and east marked "Private", and
there is a path leading south over the top of the dam."
S124: "This is what appears to have been the maintenance room for Flood Control
Dam #3. Apparently, this room has been ransacked recently, for most of the
valuable equipment is gone. On the wall in front of you is a group of buttons
colored blue, yellow, brown, and red. There are doorways to the west and
south."
S125: "You are at the base of Flood Control Dam #3, which looms above you and
to the north. The river Frigid is flowing by here. Along the river are the
White Cliffs which seem to form giant walls stretching from north to south
along the shores of the river as it winds its way downstream."
S126: "You are on the Frigid River in the vicinity of the Dam. The river flows
quietly here. There is a landing on the west shore."
S127: "You cannot go upstream due to strong currents."
S128: "The White Cliffs prevent your landing here."
S129: "The river turns a corner here making it impossible to see the Dam. The
White Cliffs loom on the east bank and large rocks prevent landing on the
west."
S130: "There is no safe landing spot here."
S131: "Just in time you steer away from the rocks."
S132: "The river descends here into a valley. There is a narrow beach on the
west shore below the cliffs. In the distance a faint rumbling can be heard."
S133: "You are on a narrow strip of beach which runs along the base of the
White Cliffs. There is a narrow path heading south along the Cliffs and a tight
passage leading west into the cliffs themselves."
S134: "The path is too narrow."
S135: "You are on a rocky, narrow strip of beach beside the Cliffs. A narrow
path leads north along the shore."
S136: "The river is running faster here and the sound ahead appears to be that
of rushing water. On the east shore is a sandy beach. A small area of beach can
also be seen below the cliffs on the west shore."
S137: "You can land either to the east or the west."
S138: "The sound of rushing water is nearly unbearable here. On the east shore
is a large landing area."
S139: "You are on the east shore of the river. The water here seems somewhat
treacherous. A path travels from north to south here, the south end quickly
turning around a sharp corner."
S140: "You are on a large sandy beach on the east shore of the river, which is
flowing quickly by. A path runs beside the river to the south here, and a
passage is partially buried in sand to the northeast."
S141: "This is a sand-filled cave whose exit is to the southwest."
S142: "It's a long way..."
S143: "You are on top of a rainbow (I bet you never thought you would walk on a
rainbow), with a magnificent view of the Falls. The rainbow travels east-west
here."
S144: "You are on a small, rocky beach on the continuation of the Frigid River
past the Falls. The beach is narrow due to the presence of the White Cliffs.
The river canyon opens here and sunlight shines in from above. A rainbow
crosses over the falls to the east and a narrow path continues to the
southwest."
S145: "You are beneath the walls of the river canyon which may be climbable
here. The lesser part of the runoff of Aragain Falls flows by below. To the
north is a narrow path."
S146: "You are on a ledge about halfway up the wall of the river canyon. You
can see from here that the main flow from Aragain Falls twists along a passage
which it is impossible for you to enter. Below you is the canyon bottom. Above
you is more cliff, which appears climbable."
S147: "You are at the top of the Great Canyon on its west wall. From here there
is a marvelous view of the canyon and parts of the Frigid River upstream.
Across the canyon, the walls of the White Cliffs join the mighty ramparts of
the Flathead Mountains to the east. Following the Canyon upstream to the north,
Aragain Falls may be seen, complete with rainbow. The mighty Frigid River flows
out from a great dark cavern. To the west and south can be seen an immense
forest, stretching for miles around. A path leads northwest. It is possible to
climb down into the canyon from here."
S148: "Nice view, lousy place to jump."
S149: "You are standing at the entrance of what might have been a coal mine.
The shaft enters the west wall, and there is another exit on the south end of
the room."
S150: "You are in a small room. Strange squeaky sounds may be heard coming from
the passage at the north end. You may also escape to the east."
S151: "This is a large room, in the middle of which is a small shaft descending
through the floor into darkness below. To the west and the north are exits from
this room. Constructed over the top of the shaft is a metal framework to which
a heavy iron chain is attached."
S152: "You wouldn't fit and would die if you could."
S153: "This is a small non-descript room. However, from the direction of a
small descending staircase a foul odor can be detected. To the south is a
narrow tunnel."
S154: "This is a small room which smells strongly of coal gas. There is a short
climb up some stairs and a narrow tunnel leading east."
S155: "This is a very small room. In the corner is a rickety wooden ladder,
leading downward. It might be safe to descend. There is also a staircase
leading upward."
S156: "This is a rather wide room. On one side is the bottom of a narrow wooden
ladder. To the west and the south are passages leaving the room."
S157: "You have come to a dead end in the mine."
S158: "This is a long and narrow passage, which is cluttered with broken
timbers. A wide passage comes from the east and turns at the west end of the
room into a very narrow passageway. From the west comes a strong draft."
S159: "You cannot fit through this passage with that load."
S160: "This is a small drafty room in which is the bottom of a long shaft. To
the south is a passageway and to the east a very narrow passage. In the shaft
can be seen a heavy iron chain."
S161: "This is a non-descript part of a coal mine."
S162: "This is a small chamber, which appears to have been part of a coal mine.
On the south wall of the chamber the letters "Granite Wall" are etched in the
rock. To the east is a long passage, and there is a steep metal slide twisting
downward. To the north is a small opening."
S163: "F"
S164: "If you insist.... Poof, you're dead!"
S165: " it at the time."
S166: "Kicking the "
S167: "You should have looked before you leaped."
S168: "In the movies, your life would be passing before your eyes."
S169: "Geronimo..."
S170: "Playing in this way with the "
S171: "Pushing the "
S172: "Fiddling with the "
S173: "Very good. Now you can go to the second grade."
S174: "Are you enjoying yourself?"
S175: "Wheeeeeeeeee!!!!!"
S176: "Do you expect me to applaud?"
S177: " hits you squarely in the head. Normally, this wouldn't do much damage,
but by incredible mischance, you fall over backwards trying to duck, and break
your neck, justice being swift and merciful in the Great Underground Empire."
S178: "Oh, no! You have walked into the slavering fangs of a lurking grue!"
S179: "Waving the "
S180: "  "
S181: "    "
S182: "      "
S183: "        "
S184: "          "
S185: " doesn't seem to work."
S186: " isn't notably helpful."
S187: " has no effect."
S188: " and devoured you!"
S189: "You can't swim in the dungeon."
S190: "Hello."
S191: "Good day."
S192: "Nice weather we've been having lately."
S193: "Goodbye."
S194: "A valiant attempt."
S195: "You can't be serious."
S196: "An interesting idea..."
S197: "What a concept!"
S198: "Look around."
S199: "Too late for that."
S200: "Have your eyes checked."
S201: "Well, you seem to have been brushing your teeth with some sort of glue.
As a result, your mouth gets glued together (with your nose) and you die of
respiratory failure."
S202: "With great effort, you open the window far enough to allow entry."
S203: "The window closes (more easily than it opened)."
S204: "The door reluctantly opens to reveal a rickety staircase descending into
darkness."
S205: "The door swings shut and closes."
S206: "A nasty-looking troll, brandishing a bloody axe, blocks all passages out
of the room."
S207: "A pathetically babbling troll is here."
S208: "An unconscious troll is sprawled on the floor. All passages out of the
room are open."
S209: "A nasty-looking troll, brandishing a bloody axe, blocks all passages out
of the room."
S210: "A troll is here."
S211: "The leaves burn, and so do you."
S212: "The grating opens."
S213: "The grating opens to reveal trees above you."
S214: "As the knife approaches its victim, your mind is submerged by an
overmastering will. Slowly, your hand turns, until the rusty blade is an inch
from your neck. The knife seems to sing as it savagely slits your throat."
S215: "I'm afraid that the leap you attempted has done you in."
S216: "You are lifted up by the rising river! You try to swim, but the currents
are too strong. You come closer, closer to the awesome structure of Flood
Control Dam #3. The dam beckons to you. The roar of the water nearly deafens
you, but you remain conscious as you tumble over the dam toward your certain
doom among the rocks at its base."
S217: "up to your ankles."
S218: "up to your shin."
S219: "up to your knees."
S220: "up to your hips."
S221: "up to your waist."
S222: "up to your chest."
S223: "up to your neck."
S224: "over your head."
S225: "high in your lungs."
S226: "The room is full of water and cannot be entered."
S227: "I'm afraid you have done drowned yourself."
S228: "The rising water carries the boat over the dam, down the river, and over
the falls. Tsk, tsk."
S229: "The cyclops, tired of all of your games and trickery, grabs you firmly.
As he licks his chops, he says "Mmm. Just like Mom used to make 'em." It's nice
to be appreciated."
S230: "The cyclops seems somewhat agitated."
S231: "The cyclops appears to be getting more agitated."
S232: "The cyclops is moving about the room, looking for something."
S233: "The cyclops was looking for salt and pepper. No doubt they are
condiments for his upcoming snack."
S234: "The cyclops is moving toward you in an unfriendly manner."
S235: "You have two choices: 1. Leave  2. Become dinner."
S236: "There is a suspicious-looking individual, holding a bag, leaning against
one wall. He is armed with a vicious-looking stiletto."
S237: "There is a suspicious-looking individual lying unconscious on the
ground."
S238: "The voice of the guardian of the dungeon booms out from the darkness,
"Your disrespect costs you your life!" and places your head on a sharp pole."
S239: "A booming voice says "Wrong, cretin!" and you notice that you have
turned into a pile of dust. How, I can't imagine."
S240: "There is a worthless piece of canvas here."
S241: "The lamp appears a bit dimmer."
S242: "The lamp is definitely dimmer now."
S243: "The lamp is nearly out."
S244: "The candles grow shorter."
S245: "The candles are becoming quite short."
S246: "The candles won't last long now."
S247: "
      ** BOOOOOOOOOOOM **"
S248: "The structural integrity of the rainbow is severely compromised, leaving
you hanging in mid-air, supported only by water vapor. Bye."
S249: "You splash around for a while, fighting the current, then you drown."
S250: "Unfortunately, the magic boat doesn't provide protection from the rocks
and boulders one meets at the bottom of waterfalls. Including this one."
S251: "Another pathetic sputter, this time from you, heralds your drowning."
S252: "In other words, fighting the fierce currents of the Frigid River. You
manage to hold your own for a bit, but then you are carried over a waterfall
and into some nasty rocks. Ouch!"
S253: "The hole collapses, smothering you."
S254: "You seem to be digging a hole here."
S255: "The hole is getting deeper, but that's about it."
S256: "You are surrounded by a wall of sand on all sides."
S257: "That was just a bit too far down."
S258: "Well, you really did it that time. Is suicide painless?"
S259: "It appears that that last blow was too much for you. I'm afraid you are
dead."
S260: "Your "
S261: " misses the "
S262: " by an inch."
S263: "A good slash, but it misses the "
S264: " by a mile."
S265: "You charge, but the "
S266: " jumps nimbly aside."
S267: "Clang! Crash! The "
S268: " parries."
S269: "A quick stroke, but the "
S270: " is on guard."
S271: "A good stroke, but it's too slow; the "
S272: " dodges."
S273: " crashes down, knocking the "
S274: " into dreamland."
S275: "The "
S276: " is battered into unconsciousness."
S277: "A furious exchange, and the "
S278: " is knocked out!"
S279: "The haft of your "
S280: " knocks out the "
S281: "."
S282: "It's curtains for the "
S283: " as your "
S284: " removes his head."
S285: "The fatal blow strikes the "
S286: " square in the heart:  He dies."
S287: " takes a fatal blow and slumps to the floor dead."
S288: " is struck on the arm; blood begins to trickle down."
S289: " pinks the "
S290: " on the wrist, but it's not serious."
S291: "Your stroke lands, but it was only the flat of the blade."
S292: "The blow lands, making a shallow gash in the "
S293: "'s arm!"
S294: " receives a deep gash in his side."
S295: "A savage blow on the thigh! The "
S296: " is stunned but can still fight!"
S297: "Slash! Your blow lands! That one hit an artery, it could be serious!"
S298: "Slash! Your stroke connects! This could be serious!"
S299: " is staggered, and drops to his knees."
S300: " is momentarily disoriented and can't fight back."
S301: "The force of your blow knocks the "
S302: " back, stunned."
S303: " is confused and can't fight back."
S304: "The quickness of your thrust knocks the "
S305: "'s weapon is knocked to the floor, leaving him unarmed."
S306: " is disarmed by a subtle feint past his guard."
S307: "The Cyclops misses, but the backwash almost knocks you over."
S308: "The Cyclops rushes you, but runs into the wall."
S309: "The Cyclops sends you crashing to the floor, unconscious."
S310: "The Cyclops breaks your neck with a massive smash."
S311: "A quick punch, but it was only a glancing blow."
S312: "A glancing blow from the Cyclops' fist."
S313: "The monster smashes his huge fist into your chest, breaking several
ribs."
S314: "The Cyclops almost knocks the wind out of you with a quick punch."
S315: "The Cyclops lands a punch that knocks the wind out of you."
S316: "Heedless of your weapons, the Cyclops tosses you against the rock wall
of the room."
S317: "The Cyclops grabs your "
S318: ", tastes it, and throws it to the ground in disgust."
S319: "The monster grabs you on the wrist, squeezes, and you drop your "
S320: " in pain."
S321: "The Cyclops seems unable to decide whether to broil or stew his dinner."
S322: "The Cyclops, no sportsman, dispatches his unconscious victim."
S323: "The troll swings his axe, but it misses."
S324: "The troll's axe barely misses your ear."
S325: "The axe sweeps past as you jump aside."
S326: "The axe crashes against the rock, throwing sparks!"
S327: "The flat of the troll's axe hits you delicately on the head, knocking
you out."
S328: "The troll neatly removes your head."
S329: "The troll's axe stroke cleaves you from the nave to the chops."
S330: "The troll's axe removes your head."
S331: "The axe gets you right in the side. Ouch!"
S332: "The flat of the troll's axe skins across your forearm."
S333: "The troll's swing almost knocks you over as you barely parry in time."
S334: "The troll swings his axe, and it nicks your arm as you dodge."
S335: "The troll charges, and his axe slashes you on your "
S336: " arm."
S337: "An axe stroke makes a deep wound in your leg."
S338: "The troll's axe swings down, gashing your shoulder."
S339: "The troll hits you with a glancing blow, and you are momentarily
stunned."
S340: "The troll swings; the blade turns on your armor but crashes broadside
into your head."
S341: "You stagger back under a hail of axe strokes."
S342: "The troll's mighty blow drops you to your knees."
S343: "The axe hits your "
S344: " and knocks it spinning."
S345: "The troll swings, you parry, but the force of his blow knocks your "
S346: " away."
S347: "The axe knocks your "
S348: " out of your hand. It falls to the floor."
S349: "The troll hesitates, fingering his axe."
S350: "The troll scratches his head ruminatively:  Might you be magically
protected, he wonders?"
S351: "Conquering his fears, the troll puts you to death."
S352: "The thief stabs nonchalantly with his stiletto and misses."
S353: "You dodge as the thief comes in low."
S354: "You parry a lightning thrust, and the thief salutes you with a grim
nod."
S355: "The thief tries to sneak past your guard, but you twist away."
S356: "Shifting in the midst of a thrust, the thief knocks you unconscious with
the haft of his stiletto."
S357: "The thief knocks you out."
S358: "Finishing you off, the thief inserts his blade into your heart."
S359: "The thief comes in from the side, feints, and inserts the blade into
your ribs."
S360: "The thief bows formally, raises his stiletto, and with a wry grin, ends
the battle and your life."
S361: "A quick thrust pinks your left arm, and blood starts to trickle down."
S362: "The thief draws blood, raking his stiletto across your arm."
S363: "The stiletto flashes faster than you can follow, and blood wells from
your leg."
S364: "The thief slowly approaches, strikes like a snake, and leaves you
wounded."
S365: "The thief strikes like a snake! The resulting wound is serious."
S366: "The thief stabs a deep cut in your upper arm."
S367: "The stiletto touches your forehead, and the blood obscures your vision."
S368: "The thief strikes at your wrist, and suddenly your grip is slippery with
blood."
S369: "The butt of his stiletto cracks you on the skull, and you stagger back."
S370: "The thief rams the haft of his blade into your stomach, leaving you out
of breath."
S371: "The thief attacks, and you fall back desperately."
S372: "A long, theatrical slash. You catch it on your "
S373: ", but the thief twists his knife, and the "
S374: " goes flying."
S375: "The thief neatly flips your "
S376: " out of your hands, and it drops to the floor."
S377: "You parry a low thrust, and your "
S378: " slips out of your hand."
S379: "The thief, a man of superior breeding, pauses for a moment to consider
the propriety of finishing you off."
S380: "The thief amuses himself by searching your pockets."
S381: "The thief entertains himself by rifling your pack."
S382: "The thief, forgetting his essentially genteel upbringing, cuts your
throat."
S383: "The thief, a pragmatist, dispatches you as a threat to his livelihood."
S384: "coins"
S385: "jewels"

[End of text]

[End of file]
