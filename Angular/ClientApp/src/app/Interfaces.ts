export interface Message {
  Id: number,
  Name: string,
  MessageContent: string;
}

export interface MyResponse {
  Success: number,
  Data: any,
  Message: string 
}
