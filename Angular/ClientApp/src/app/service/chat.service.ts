import { Injectable, Inject } from "@angular/core";
import { Message, MyResponse } from "../Interfaces";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}

@Injectable({
  providedIn: 'root'
})

export class ChatService {
  baseUrl: string;
  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
}

  public GetMessage(): Observable<Message[]> {
    let http: HttpClient;
    return this.http.get<Message[]>(this.baseUrl + "api/chat/message");
  }

  public AddMessage(name, text) {
    this.http.post<MyResponse>(this.baseUrl + 'api/Chat/Add',
      { 'Name': name, 'MessageContent': text }, httpOptions).subscribe(
        result => {
          console.log(result);
        },
        error => console.error(error)
      );
  }
}


