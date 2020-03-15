import { Group } from '../groups/group.interface';

export interface User {
  userId : number;
  firstName : string ;
  lastName : string ;
  userName : string ;
  password : string ;
  userGroups? : UserGroups[];
}


export interface UserGroups{
  userId : number;
  user : User;
  groupId : number;
  group : Group
}