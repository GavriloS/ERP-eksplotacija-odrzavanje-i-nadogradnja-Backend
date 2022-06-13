import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISession } from '../models/Session.model';
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';

declare const Stripe: any;

@Injectable({
  providedIn: 'root'
})
export class StripeService {
  backendUrl: string = environment.backendUrl;

  constructor(private http:HttpClient,
              private authService:AuthService) { }

  requestMemberSession(prices:Record<string,number>): void {
    console.log(prices);
    this.http
      .post<ISession>(this.backendUrl + 'api/stripe/create-checkout-session', {
        prices: prices,
        successUrl: 'http://localhost:4200/success',
        failureUrl: 'http://localhost:4200/failure',
        clientReferenceId: this.authService.user.getValue().userId
      })
      .subscribe((session) => {
        this.redirectToCheckout(session);
      });
  }

  requestMemberSessionMembership(prices:Record<string,number>,userId:string): void {

    this.http
      .post<ISession>(this.backendUrl + 'api/stripe/create-checkout-session-membership', {
        prices: prices,
        successUrl: 'http://localhost:4200/success/membership/'+userId,
        failureUrl: 'http://localhost:4200/failure',
        clientReferenceId: this.authService.user.getValue().userId
      })
      .subscribe((session) => {
        this.redirectToCheckout(session);
      });
  }

  redirectToCheckout(session: ISession) {
    const stripe = Stripe(session.publicKey);

    stripe.redirectToCheckout({
      sessionId: session.sessionId,

    });
  }
}
