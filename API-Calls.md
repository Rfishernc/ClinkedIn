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
ReleaseDate: {YYYY/MM/DD}
```
### Example 
```
"Username": "Nathan",
"Interests": [0,3,4],
"Services": ["building shanks", "using shanks", "smelling flowers"],
"ReleaseDate": "2099/12/26"
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
`member/0/friends` - member/{id}/friends
Pass the user ID in the URL and the friend to add in the body of the request.
```
FriendId: {int matching the friend to add}
```
### Example
```
"FriendId": 3
```

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
`member/0/friends` - member/{id}/friends
Pass the users ID in the URL and the ID of the friend to remove in the body.
```
FriendId: {Int matching a friends ID to remove}
```
### Example
```
"FriendId": 0
```

## Get Friends by interest
`findmembers` - findmembers --
Pass an array of interest ID's to return an array of members that contain those interest IDs
```
InterestIds: [array of ints]
```
### Example
```
"InterestIds":[1,2]
```

## Delete Interests
`interest` - interest --
Removes interests from the member selected
Pass the user ID and the interest IDs to remove in the body
```
InterestId: {[array of ints]},
MemberId: {int matching user}
```
### Example
```
"InterestId": [0],
"MemberId": 0
```

## Post User Services
`service` - service --
adds array of services to member services list
```
MemberId: {int matching user},
Services: {[array of strings to be listed as services]}
```
### Example
```
"MemberId": 0,
"Services": ["licking cell doors", "eating dropped food"]
```

## Delete User Services
`service` - service --
Deletes the matched services from the matched user
```
MemberId: {int matching user},
Services: {[array of strings to be removed as services]}
```
### Example
```
"MemberId": 0,
"Services": ["licking cell doors"]
```

## Get Warden Inmate Access
`warden` - warden --
Gets all inmates when the User is the Warden
Pass the following in the header
```
Header - Authorization: Value - {Authorization ID}
```
### Example
```
Authorization: 123456
```

