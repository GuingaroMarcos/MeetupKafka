import { Injectable, OnInit } from "@angular/core";
import { Notifications } from "../../models/Notification";


@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private description: string;
  private notification: Notifications;
  private numeroNotificacao: number = 0;
  constructor() {}

  //public getNotification(): Notifications {

  //  this.sinalRService.startConnection();

  //  this.description = this.sinalRService.GetNotification();

  //  this.notification.desctiption = this.description;

  //  this.notification.count = this.numeroNotificacao + 1;

  //  console.log(this.notification);

  //  return this.notification;
  //}

}
