# Vandal Voice - Quick Start Guide
A Data Volley voice programming application.

## Usage
### Service
	"opponent number" || "number"  +  [playerNumber]  +  "serve" || "serve-error" || "serve-ace"
### Pass
	"opponent number" || "number"  +  [playerNumber]  +  "receive" + [passRating]
### Set (only account errors)
	"opponent number" || "number"  +  [playerNumber]  +  "set-error"
### Attack
	"opponent number" || "number"  +  [playerNumber]  +  "attack" + [hittingCall] + [attackRating]
### Block
	"opponent number" || "number"  +  [playerNumber]  +  "block" + [blockRating]


#### [playerNumber]
	1-29

#### [passRating]
	"three-pass", "two-pass", "one-pass", "error"

#### [hittingCall]
	"fifty-one", "fifty-two", "super", "fourty-two", "two-two", "thirty-one", "two-one", 
    "tye", "wave", "jett", "thirty-two", "A-two", "red", "pink", "pipe", "b", "c", "dump", 
    "over-pass"

#### [attackRating]
	"continue", "error", "kill", "blocked"

#### [blockRating]
	"kill", "error"

### Other Commands
#### "Done
	Copies codes to clipboard and empties string for next play.
#### "Undo"
	Undoes previous play.
#### "Reset"
	Clears all plays