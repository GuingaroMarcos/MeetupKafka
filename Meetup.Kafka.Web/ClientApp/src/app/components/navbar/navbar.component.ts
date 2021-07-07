import { Component, OnInit, ElementRef } from '@angular/core';
import { ROUTES } from '../sidebar/sidebar.component';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { Router } from '@angular/router';
import { NotificationService } from '../../services/Notification/notification.service';
import { Notifications } from '../../models/Notification';
import * as signalR from "@aspnet/signalr"; 

interface INoficicacoes {
  name: string;
  status: number;
}

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  private listTitles: any[];
  private location: Location;
  private notification: Notifications;
  Noficicacoes: INoficicacoes[] = [];
  private numeroNotificacoes: number = 0;
  constructor(location: Location) {
    this.location = location;
   
  }

  ngOnInit() {
    this.listTitles = ROUTES.filter(listTitle => listTitle);
    this.startConnection();
  };

  getTitle() {
    var titlee = this.location.prepareExternalUrl(this.location.path());
    if (titlee.charAt(0) === '#') {
      titlee = titlee.slice(1);
    }

    for (var item = 0; item < this.listTitles.length; item++) {
      if (this.listTitles[item].path === titlee) {
        return this.listTitles[item].title;
      }
    }
    return 'Dashboard';
  }

  private hubConnection: signalR.HubConnection
  public startConnection = () => {

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('/notificationHub')
      .build();

    this.hubConnection
      .start()
      .then(() => {
        this.hubConnection.on('ReadNotification', (value) => {
          this.notification = Object.assign({}, this.notification, JSON.parse(value.message.value));
          console.log(JSON.parse(value.message.value));
          console.log(this.notification);
          this.Noficicacoes.push({ name: this.notification.Name, status: this.notification.Status });
          this.numeroNotificacoes = this.numeroNotificacoes + 1;
        });
      })
      .catch(err => console.log('Error while starting connection: ' + err))
  }

}
