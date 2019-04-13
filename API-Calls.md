## API Calls
Pull up postman/insomnia to pass in the below examples
Run the IIS Express in Visual Studios to get the sample server up and running

### Base URL
`https://localhost:44320/api`

## Get User
`member/0` - member/{memberid} --
This returns the specified member. You pass the member ID into the URL and it will return the member along with the member's properties.

## Get release date
`member/0/release` - member/{memberId}/release --
This returns the number of days until the inmate that matched the member ID has until they are set to be released

## Get User enemies
`member/0/enemies` - member/{memberId}/enemies --
This returns all enemies of the inmate that matches the member ID

## Get User friends
`member/0/friends` - member/{memberId}/friends --
This returns all friends of the inmate that matches the member ID

## Post User
`memberjoin/join` - memberjoin/join --
Optionally pass to the body the following:
```
Username: {string},
Interests: {[An array of ints between 0-5]},
Services: {[An array of strings]},
ReleaseDate: {a datetime number}
```
### Example 
```
"Username": "Nathan",
"Interests": [0,3,4],
"Services": ["building shanks", "using shanks", "smelling flowers"],
ReleaseDate: 1655174314
```

## Post User Enemy
`member/enemies` - member/enemies --
Pass the member Id and adds a single enemy ID to the enemies property. Pass the following to the body
```
MemberId: {int matching user}
EnemyId: {int matching member to be added as enemy}
```
### Example
```
"MemberId": 0,
"EnemyId": 1
```

## Post User Friend
WIP

## Delete User Enemy
`member/enemies` - member/enemies --
Pass the member ID and a single enemy ID to remove the ID from the enemies property. Pass the following to the body
```
MemberId: {int matching user}
EnemyId: {int matching member to be removed as enemy}
```
### Example
```
"MemberId": 0,
"EnemyId": 1
```

## Delete User Friend
WIP

## Get Find 
