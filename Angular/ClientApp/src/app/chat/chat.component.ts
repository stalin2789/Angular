import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'chat-app',
  templateUrl: './chat.component.html'
})

export class ChatComponent {
  public lstMessages: string[];

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    http.get<Message[]>(baseUrl + "api/chat/message").subscribe(result => {
      this.lstMessages = result;
    }, error => console.error(error));
  }
}

interface Message {
  Id: number,
  Name: string,
  MessageContent: string;
}
