﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZMachineRunner
{
    /// <summary>
    /// Contains the complete game walkthrough which is a great way to validate that it has executed correctly
    /// </summary>
    static class Walkthrough
    {
        const string WALKTHOUGH_COMMANDS_2 = "n, e, open window, enter, take all, w, take all, move rug, open trapdoor, light lamp, d, n";

        // thanks to https://www.abandonwaredos.com/docs.php?sf=Zork1_solution.txt&st=walkthrough&sg=Zork+I%3A+The+Great+Underground+Empire&idg=1405
        const string WALKTHOUGH_COMMANDS =
@"(You begin outside a white house) N, E, E, N, W, U (into the tree), GET EGG, D,
S, E, OPEN WINDOW, IN, GET SACK AND BOTTLE, W, GET LAMP AND SWORD, E, U, LIGHT
LAMP, GET ROPE AND KNIFE, D, W, MOVE RUG (under it is a trapdoor), OPEN
TRAPDOOR, D (someboyd slams the trapdoor shut), N, KILL TROLL WITH SWORD, <9>, <1> (till
he dies), DROP SWORD, S, S, E, GET PAINTING, W, N, N, W, W, W, U, GET BAG, SW,
E, S, SE, OPEN SACK (you notice some food and a clove of garlic), GIVE LUNCH AND
WATER TO CYCLOPS (he falls asleep), ULYSSES (startled, he runs off and breaks
the door in the process! You ought to save your game here), U (the thief appears
and attacks you), <1>, <1>, GIVE EGG TO THIEF, KILL THIEF WITH KNIFE, <9>, <4>, <1>, <1>,
KILL THIEF WITH KNIFE, <9>, <3> (until he dies. You may then take the 
chalice and the now open egg), DROP KNIFE, GET
CHALICE AND EGG, D, E, E, OPEN CASE, PUT PAINTING AND CHALICE AND COINS IN CASE,
TURN OFF LAMP, E, E, E, N, W, WIND UP CANARY (inside the egg. A bird flies into
view and drops a bauble), GET BAUBLE, GET CANARY, S, E, IN, W, PUT EGG AND BAUBLE
AND CANARY IN CASE, OPEN TRAPDOOR, D, LIGHT LAMP, N, E, E, SE, E, TIE ROPE TO
RAILING, D, GET TORCH, EXTINGUISH LAMP, S, DROP ALL BUT TORCH, E, OPEN COFFIN
(you find a sceptre), GET COFFIN AND SCEPTRE, W, TEMPLE (you are teleported to
the thief's treasure chamber), D, E, E, PUT COFFIN IN CASE, E, E, E, E, D, D, N,
WAVE SCEPTRE (the rainbow becomes solid), E, W, GET POT (the usual one!), SW, U,
U, W, N, W, IN, W, PUT POT AND SCEPTRE IN CASE, D, N, E, E, E, ECHO (the echo
changes), GET BAR, U, E, N, GET MATCHBOOK, N, GET WRENCH AND SCREWDRIVER, PRESS
YELLOW (the bubble by the dam starts glowing), S, S, TURN BOLT WITH WRENCH (the
water drains away), DROP WRENCH, W, WAIT, WAIT, WAIT, WAIT, WAIT (5 times. The water level is low enough
for you to cross the river), N, GET TRUNK, N, GET PUMP, S, S, SE, D, W, SE, E,
D, S, TEMPLE (to the treasure chamber), D, E, E, PUT BAR AND TRUNK IN CASE, W,
W, U, TEMPLE (back again), GET ALL (incl. BELL), S, PUT PUMP IN SACK, GET BOOK AND CANDLES,
BLOW OUT CANDLES, D, D, RING BELL (the spirits are frightened. You drop the candles),
LIGHT MATCH, LIGHT CANDLES WITH MATCH (the spirits are terrified), READ PRAYER
(they make their escape), S, DROP BOOK AND CANDLES, GET SKULL, N, U, N, N, N, E,
U, E, D, INFLATE BOAT WITH PUMP (the plastic is actually a small boat!), DROP
PUMP, GET IN BOAT, LAUNCH IT, WAIT, WAIT, WAIT, WAIT, WAIT, WAIT, WAIT, WAIT, WAIT, WAIT (you sail down-river to a buoy), GET BUOY, 
E, GET OUT OF BOAT, DROP BUOY, OPEN IT (it contains and emerald), GET EMERALD, DROP MATCHBOOK, GET SHOVEL, 
NE, DIG IN SAND WITH SHOVEL, AGAIN, AGAIN, AGAIN (you uncover a
scarab), DROP SHOVEL, GET SCARAB, SW, S, S, W (across the rainbow), W, SW, U, U,
W, N, W, IN, W, PUT SKULL IN CASE, PUT EMERALD IN CASE, PUT SCARAB IN CASE, D, N, E, N, NE, N, N, N,
GET TRIDENT, U, N, N, W, N, W, GET GARLIC, N (the bat stays away, thanks to the
garlic), E, PUT TORCH AND SCREWDRIVER IN BASKET, N, LIGHT LAMP, D, GET BRACELET,
E, NE, SE, SW, D, D, S, GET COAL, N, U, U, N, E, S, N, U, S, PUT COAL IN BASKET,
LOWER BASKET (to 'Drafty Room'), N, D, E, NE, SE, SW, D, D, W, DROP ALL, W, GET
COAL, GET TORCH, GET SCREWDRIVER, S, OPEN LID, PUT COAL IN MACHINE (to be found again
in \""Zork III\""!), CLOSE LID, TURN SWITCH WITH SCREWDRIVER (the coal turns into a
diamond), OPEN LID, GET DIAMOND, DROP SCREWDRIVER, N, PUT TORCH AND DIAMOND IN
BASKET, E, 
GET LANTERN, GET TRIDENT, GET GARLIC, GET BRACELET,
E, U, U, N, E, S, N, U, S, RAISE BASKET,
GET DIAMOND AND TORCH, W, GET FIGURINE, S, E, S, D(through the slide to
'Cellar'), U, PUT FIGURINE IN CASE, PUT TRIDENT IN CASE, PUT BRACELET IN CASE, PUT DIAMOND IN CASE, PUT TORCH IN CASE (a map
 appears in the case), GET MAP, E, E, S, W, SW (using the secret path), ENTER
 BARROW(""Zork II"" awaits.Later!!)";

        static List<string> _commands = null;
        public static int _index = 0;


        static Walkthrough()
        {
            buildWalkthoughCommands();
        }

        public static void MoveBackCommand()
        {
            _index = _index - 1;
        }

        public static string GetNextCommand()
        {
            if (_index == _commands.Count)
            {
                return "";
            }

            var command = _commands[_index];

            if (command == "stop")
            {
                return "";
            }
            else
            {
                _index++;
                return command;
            }

        }

        public static ushort GetNextRandomNumber()
        {
            var command = _commands[_index];

            if ((!command.StartsWith("<")) || (!command.EndsWith(">")))
            {
                return 0;
            }

            _index++;
            return ushort.Parse(command.Substring(1, command.Length - 2));
        }

        static void buildWalkthoughCommands()
        {

            var walkthroughCommands = WALKTHOUGH_COMMANDS.Replace("\r\n", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");

            var commands = new List<string>();

            var currentCommand = "";
            var inBrackets = false;

            foreach (var c in walkthroughCommands)
            {
                switch (c)
                {
                    case '(':
                        if (!inBrackets)
                        {
                            inBrackets = true;
                        }
                        else
                        {
                            throw new Exception();
                        }
                        break;

                    case ')':
                        if (inBrackets)
                        {
                            inBrackets = false;
                        }
                        else
                        {
                            throw new Exception();
                        }
                        break;

                    case ',':
                        if (!inBrackets)
                        {
                            commands.Add(currentCommand.Trim().ToLower());
                            currentCommand = "";
                        }
                        break;

                    default:
                        if (!inBrackets)
                        {
                            currentCommand += c;
                        }
                        break;
                }

            }

            commands.Add(currentCommand.Trim().ToLower());
            _commands = commands;
        }


    }
}
