﻿/// Implementation file for parser generated by the fsyacc-compatibility backend for fsharpyacc.
module internal FSharpYacc.Parser

#nowarn "64" // turn off warnings that type variables used in production annotations are instantiated to concrete type

open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers


(*
Copyright (c) 2012-2013, Jack Pappas
All rights reserved.

This code is provided under the terms of the 2-clause ("Simplified") BSD license.
See LICENSE.TXT for licensing details.
*)

(* NOTE :   The code below is adapted from the 'fsyacc' grammar, which is
            (c) Microsoft Corporation 2005-2008 and covered under the
            Apache 2.0 license. *)

open Graham.Grammar
open FSharpYacc.Ast

// Turn off ML-compatibility-only warnings.
#nowarn "62"



// This type is the type of tokens accepted by the parser
type token =
    | BAR
    | CODE of (CodeFragment option)
    | COLON
    | EOF
    | ERROR
    | GREATER
    | HEADER of (CodeFragment option)
    | IDENT of (string)
    | LEFT
    | LESS
    | NONASSOC
    | PERCENT_PERCENT
    | PREC
    | RIGHT
    | SEMI
    | START
    | TOKEN of (string option)
    | TYPE of (string)

/// This type is used to give symbolic names to token indexes, useful for error messages.
type private tokenId =
    | TOKEN_BAR
    | TOKEN_CODE
    | TOKEN_COLON
    | TOKEN_EOF
    | TOKEN_ERROR
    | TOKEN_GREATER
    | TOKEN_HEADER
    | TOKEN_IDENT
    | TOKEN_LEFT
    | TOKEN_LESS
    | TOKEN_NONASSOC
    | TOKEN_PERCENT_PERCENT
    | TOKEN_PREC
    | TOKEN_RIGHT
    | TOKEN_SEMI
    | TOKEN_START
    | TOKEN_TOKEN
    | TOKEN_TYPE
    | TOKEN_end_of_input
    | TOKEN_error

/// This type is used to give symbolic names to token indexes, useful for error messages.
type private nonterminalId =
    | NONTERM__startspec
    | NONTERM_clause
    | NONTERM_clauses
    | NONTERM_decl
    | NONTERM_decls
    | NONTERM_headeropt
    | NONTERM_idents
    | NONTERM_optbar
    | NONTERM_optprec
    | NONTERM_optsemi
    | NONTERM_rule
    | NONTERM_rules
    | NONTERM_spec
    | NONTERM_syms

/// Maps tokens to integer indexes.
let private tagOfToken = function
    | BAR -> 0
    | CODE _ -> 1
    | COLON -> 2
    | EOF -> 3
    | ERROR -> 4
    | GREATER -> 5
    | HEADER _ -> 6
    | IDENT _ -> 7
    | LEFT -> 8
    | LESS -> 9
    | NONASSOC -> 10
    | PERCENT_PERCENT -> 11
    | PREC -> 12
    | RIGHT -> 13
    | SEMI -> 14
    | START -> 15
    | TOKEN _ -> 16
    | TYPE _ -> 17

/// Maps integer indices to symbolic token ids.
let private tokenTagToTokenId = function
    | 0 -> TOKEN_BAR
    | 1 -> TOKEN_CODE
    | 2 -> TOKEN_COLON
    | 3 -> TOKEN_EOF
    | 4 -> TOKEN_ERROR
    | 5 -> TOKEN_GREATER
    | 6 -> TOKEN_HEADER
    | 7 -> TOKEN_IDENT
    | 8 -> TOKEN_LEFT
    | 9 -> TOKEN_LESS
    | 10 -> TOKEN_NONASSOC
    | 11 -> TOKEN_PERCENT_PERCENT
    | 12 -> TOKEN_PREC
    | 13 -> TOKEN_RIGHT
    | 14 -> TOKEN_SEMI
    | 15 -> TOKEN_START
    | 16 -> TOKEN_TOKEN
    | 17 -> TOKEN_TYPE
    | 19 -> TOKEN_end_of_input
    | 18 -> TOKEN_error
    | tokenIdx ->
        failwithf "tokenTagToTokenId: Invalid token. (Tag = %i)" tokenIdx

/// Maps production indexes returned in syntax errors to strings representing
/// the non-terminal that would be produced by that production.
let private prodIdxToNonTerminal = function
    | 0 -> NONTERM__startspec
    | 1 -> NONTERM_clause
    | 2 -> NONTERM_clauses
    | 3 -> NONTERM_clauses
    | 4 -> NONTERM_decl
    | 5 -> NONTERM_decl
    | 6 -> NONTERM_decl
    | 7 -> NONTERM_decl
    | 8 -> NONTERM_decl
    | 9 -> NONTERM_decl
    | 10 -> NONTERM_decls
    | 11 -> NONTERM_decls
    | 12 -> NONTERM_headeropt
    | 13 -> NONTERM_headeropt
    | 14 -> NONTERM_idents
    | 15 -> NONTERM_idents
    | 16 -> NONTERM_optbar
    | 17 -> NONTERM_optbar
    | 18 -> NONTERM_optprec
    | 19 -> NONTERM_optprec
    | 20 -> NONTERM_optsemi
    | 21 -> NONTERM_optsemi
    | 22 -> NONTERM_rule
    | 23 -> NONTERM_rules
    | 24 -> NONTERM_rules
    | 25 -> NONTERM_spec
    | 26 -> NONTERM_syms
    | 27 -> NONTERM_syms
    | 28 -> NONTERM_syms
    | prodIdx ->
        failwithf "prodIdxToNonTerminal: Invalid production index. (Index = %i)" prodIdx

let [<Literal>] private _fsyacc_endOfInputTag = 19
let [<Literal>] private _fsyacc_tagOfErrorTerminal = 18

/// Gets the name of a token as a string.
let token_to_string = function
    | BAR -> "BAR"
    | CODE _ -> "CODE"
    | COLON -> "COLON"
    | EOF -> "EOF"
    | ERROR -> "ERROR"
    | GREATER -> "GREATER"
    | HEADER _ -> "HEADER"
    | IDENT _ -> "IDENT"
    | LEFT -> "LEFT"
    | LESS -> "LESS"
    | NONASSOC -> "NONASSOC"
    | PERCENT_PERCENT -> "PERCENT_PERCENT"
    | PREC -> "PREC"
    | RIGHT -> "RIGHT"
    | SEMI -> "SEMI"
    | START -> "START"
    | TOKEN _ -> "TOKEN"
    | TYPE _ -> "TYPE"

/// Gets the data carried by a token as an object.
let private _fsyacc_dataOfToken = function
    | BAR -> (null : System.Object)
    | CODE _fsyacc_x -> box _fsyacc_x
    | COLON -> (null : System.Object)
    | EOF -> (null : System.Object)
    | ERROR -> (null : System.Object)
    | GREATER -> (null : System.Object)
    | HEADER _fsyacc_x -> box _fsyacc_x
    | IDENT _fsyacc_x -> box _fsyacc_x
    | LEFT -> (null : System.Object)
    | LESS -> (null : System.Object)
    | NONASSOC -> (null : System.Object)
    | PERCENT_PERCENT -> (null : System.Object)
    | PREC -> (null : System.Object)
    | RIGHT -> (null : System.Object)
    | SEMI -> (null : System.Object)
    | START -> (null : System.Object)
    | TOKEN _fsyacc_x -> box _fsyacc_x
    | TYPE _fsyacc_x -> box _fsyacc_x

let private _fsyacc_gotos = [| 0us; 65535us; 2us; 65535us; 28us; 30us; 36us; 30us; 2us; 65535us; 28us; 31us; 36us; 43us; 2us; 65535us; 3us; 10us; 10us; 10us; 2us; 65535us; 3us; 11us; 10us; 19us; 1us; 65535us; 0us; 3us; 7us; 65535us; 4us; 12us; 5us; 14us; 6us; 15us; 7us; 16us; 8us; 17us; 9us; 18us; 13us; 21us; 1us; 65535us; 25us; 28us; 1us; 65535us; 29us; 34us; 1us; 65535us; 31us; 38us; 2us; 65535us; 20us; 23us; 23us; 23us; 2us; 65535us; 20us; 24us; 23us; 26us; 1us; 65535us; 0us; 1us; 4us; 65535us; 28us; 29us; 32us; 39us; 33us; 40us; 36us; 29us; |]
let private _fsyacc_sparseGotoTableRowOffsets = [| 0us; 1us; 4us; 7us; 10us; 13us; 15us; 23us; 25us; 27us; 29us; 32us; 35us; 37us; |]
let private _fsyacc_stateToProdIdxsTableElements = [| 4us; 0us; 13us; 12us; 25us; 1us; 0us; 1us; 12us; 9us; 7us; 9us; 8us; 6us; 4us; 5us; 10us; 11us; 25us; 3us; 7us; 15us; 14us; 3us; 9us; 15us; 14us; 3us; 8us; 15us; 14us; 3us; 6us; 15us; 14us; 3us; 4us; 15us; 14us; 3us; 5us; 15us; 14us; 9us; 7us; 9us; 8us; 6us; 4us; 5us; 10us; 11us; 11us; 1us; 25us; 1us; 7us; 3us; 15us; 14us; 14us; 1us; 9us; 1us; 8us; 1us; 6us; 1us; 4us; 1us; 5us; 1us; 11us; 4us; 22us; 24us; 23us; 25us; 1us; 14us; 1us; 22us; 5us; 22us; 24us; 24us; 23us; 23us; 1us; 25us; 3us; 16us; 17us; 22us; 1us; 23us; 1us; 17us; 7us; 1us; 3us; 2us; 22us; 28us; 27us; 26us; 3us; 1us; 18us; 19us; 2us; 3us; 2us; 3us; 20us; 21us; 22us; 4us; 28us; 27us; 27us; 26us; 4us; 28us; 27us; 26us; 26us; 1us; 1us; 1us; 19us; 7us; 1us; 3us; 2us; 2us; 28us; 27us; 26us; 1us; 21us; 1us; 22us; 1us; 27us; 1us; 26us; 1us; 1us; 1us; 19us; 1us; 2us; |]
let private _fsyacc_stateToProdIdxsTableRowOffsets = [| 0us; 5us; 7us; 9us; 19us; 23us; 27us; 31us; 35us; 39us; 43us; 53us; 55us; 57us; 61us; 63us; 65us; 67us; 69us; 71us; 73us; 78us; 80us; 82us; 88us; 90us; 94us; 96us; 98us; 106us; 110us; 113us; 117us; 122us; 127us; 129us; 131us; 139us; 141us; 143us; 145us; 147us; 149us; 151us; |]
let [<Literal>] private _fsyacc_action_rows = 44
let private _fsyacc_actionTableElements = [| 2us; 16397us; 6us; 2us; 18us; 32768us; 1us; 32768us; 19us; 49152us; 1us; 16396us; 18us; 32768us; 7us; 16394us; 8us; 4us; 10us; 5us; 13us; 6us; 15us; 7us; 16us; 8us; 17us; 9us; 18us; 32768us; 2us; 16399us; 7us; 13us; 18us; 32768us; 2us; 16399us; 7us; 13us; 18us; 32768us; 2us; 16399us; 7us; 13us; 18us; 32768us; 2us; 16399us; 7us; 13us; 18us; 32768us; 2us; 16399us; 7us; 13us; 18us; 32768us; 2us; 16399us; 7us; 13us; 18us; 32768us; 7us; 16394us; 8us; 4us; 10us; 5us; 13us; 6us; 15us; 7us; 16us; 8us; 17us; 9us; 18us; 32768us; 1us; 32768us; 11us; 20us; 1us; 16391us; 18us; 32768us; 2us; 16399us; 7us; 13us; 18us; 32768us; 1us; 16393us; 18us; 32768us; 1us; 16392us; 18us; 32768us; 1us; 16390us; 18us; 32768us; 1us; 16388us; 18us; 32768us; 1us; 16389us; 18us; 32768us; 1us; 16395us; 18us; 32768us; 1us; 32768us; 7us; 22us; 1us; 16398us; 18us; 32768us; 1us; 32768us; 2us; 25us; 2us; 16408us; 7us; 22us; 18us; 32768us; 1us; 16409us; 18us; 32768us; 2us; 16400us; 0us; 27us; 18us; 32768us; 1us; 16407us; 18us; 32768us; 1us; 16401us; 18us; 32768us; 3us; 16412us; 4us; 32us; 7us; 33us; 18us; 32768us; 2us; 16402us; 12us; 35us; 18us; 32768us; 2us; 16387us; 0us; 36us; 18us; 32768us; 2us; 16404us; 14us; 37us; 18us; 32768us; 3us; 16412us; 4us; 32us; 7us; 33us; 18us; 32768us; 3us; 16412us; 4us; 32us; 7us; 33us; 18us; 32768us; 1us; 32768us; 1us; 41us; 1us; 32768us; 7us; 42us; 3us; 16412us; 4us; 32us; 7us; 33us; 18us; 32768us; 1us; 16405us; 18us; 32768us; 1us; 16406us; 18us; 32768us; 1us; 16411us; 18us; 32768us; 1us; 16410us; 18us; 32768us; 1us; 16385us; 18us; 32768us; 1us; 16403us; 18us; 32768us; 1us; 16386us; 18us; 32768us; |]
let private _fsyacc_actionTableRowOffsets = [| 0us; 3us; 5us; 7us; 15us; 18us; 21us; 24us; 27us; 30us; 33us; 41us; 43us; 45us; 48us; 50us; 52us; 54us; 56us; 58us; 60us; 62us; 64us; 66us; 69us; 71us; 74us; 76us; 78us; 82us; 85us; 88us; 91us; 95us; 99us; 101us; 103us; 107us; 109us; 111us; 113us; 115us; 117us; 119us; |]
let private _fsyacc_reductionSymbolCounts = [| 1us; 3us; 3us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 0us; 2us; 1us; 0us; 2us; 0us; 0us; 1us; 0us; 2us; 0us; 1us; 5us; 2us; 1us; 4us; 2us; 2us; 0us; |]
let private _fsyacc_productionToNonTerminalTable = [| 0us; 1us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 4us; 4us; 5us; 5us; 6us; 6us; 7us; 7us; 8us; 8us; 9us; 9us; 10us; 11us; 11us; 12us; 13us; 13us; 13us; |]
let private _fsyacc_immediateActions = [| 65535us; 49152us; 16396us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16391us; 65535us; 16393us; 16392us; 16390us; 16388us; 16389us; 16395us; 65535us; 16398us; 65535us; 65535us; 16409us; 65535us; 16407us; 16401us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16405us; 16406us; 16411us; 16410us; 16385us; 16403us; 16386us; |]
let private _fsyacc_reductions () = [|
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Specification)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                raise (Microsoft.FSharp.Text.Parsing.Accept (Microsoft.FSharp.Core.Operators.box _1))
                )
            : '_startspec))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'syms)) in
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'optprec)) in
        let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : CodeFragment option)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                         
                // Rule
                {   Symbols = _1;
                    Action = _3;
                    ImpersonatedPrecedence = _2; } 
                )
            : 'clause))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'clause)) in
        let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'clauses)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                           _1 :: _3 
                )
            : 'clauses))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'clause)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                [_1] 
                )
            : 'clauses))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string option)) in
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'idents)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                    
                (fun x -> { x with TerminalDeclarations = x.TerminalDeclarations @ [(_1, _2)] }) 
                )
            : 'decl))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'idents)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                   
                (fun x -> { x with NonterminalDeclarations = x.NonterminalDeclarations @ (_2 |> List.map (fun x -> _1, x)); }) 
                )
            : 'decl))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'idents)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                    
                (fun x -> { x with StartingProductions = x.StartingProductions @ _2}) 
                )
            : 'decl))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'idents)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                   
                (fun x -> { x with Associativities = x.Associativities @ [(Associativity.Left, _2)]; }) 
                )
            : 'decl))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'idents)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                    
                (fun x -> { x with Associativities = x.Associativities @ [(Associativity.Right, _2)]; }) 
                )
            : 'decl))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'idents)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                       
                (fun x -> { x with Associativities = x.Associativities @ [(Associativity.NonAssociative, _2)]; }) 
                )
            : 'decl))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        Microsoft.FSharp.Core.Operators.box
            (
                (
                [] 
                )
            : 'decls))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'decl)) in
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'decls)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                   _1 :: _2 
                )
            : 'decls))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : CodeFragment option)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                _1 
                )
            : 'headeropt))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        Microsoft.FSharp.Core.Operators.box
            (
                (
       
                //"", (parseState.ResultRange |> fst)
                None 
                )
            : 'headeropt))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'idents)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                     _1 :: _2 
                )
            : 'idents))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        Microsoft.FSharp.Core.Operators.box
            (
                (
                    [] 
                )
            : 'idents))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        Microsoft.FSharp.Core.Operators.box
            (
                (
        
                )
            : 'optbar))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        Microsoft.FSharp.Core.Operators.box
            (
                (
            
                )
            : 'optbar))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        Microsoft.FSharp.Core.Operators.box
            (
                (
                    None 
                )
            : 'optprec))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                   Some _2 
                )
            : 'optprec))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        Microsoft.FSharp.Core.Operators.box
            (
                (
        
                )
            : 'optsemi))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        Microsoft.FSharp.Core.Operators.box
            (
                (
             
                )
            : 'optsemi))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
        let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'optbar)) in
        let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'clauses)) in
        let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : 'optsemi)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                                           (_1, _4) 
                )
            : 'rule))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'rule)) in
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'rules)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                   _1 :: _2 
                )
            : 'rules))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'rule)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                [_1] 
                )
            : 'rules))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'headeropt)) in
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'decls)) in
        let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'rules)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                List.foldBack (fun f x -> f x) _2 {
                    Header = _1;
                    Footer = None;
                    NonterminalDeclarations = List.empty;
                    TerminalDeclarations = List.empty;
                    StartingProductions = List.empty;
                    Associativities = List.empty;
                    Productions = _4; } 
                )
            : Specification))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'syms)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                   _1 :: _2 
                )
            : 'syms))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'syms)) in
        Microsoft.FSharp.Core.Operators.box
            (
                (
                   "error" :: _2 
                )
            : 'syms))
    (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
        Microsoft.FSharp.Core.Operators.box
            (
                (
                    [] 
                )
            : 'syms))
    |]

let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = {
    reductions = _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken;
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError =
        (fun (ctxt : Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) ->
            match parse_error_rich with
            | Some f -> f ctxt
            | None -> parse_error ctxt.Message);
    numTerminals = 20;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable;
    }
    
let engine lexer lexbuf startState =
    (tables ()).Interpret(lexer, lexbuf, startState)

let spec lexer lexbuf : Specification =
    unbox ((tables ()).Interpret(lexer, lexbuf, 0))

