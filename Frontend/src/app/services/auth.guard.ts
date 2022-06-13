import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router
} from "@angular/router";
import { Injectable } from "@angular/core";
import { map, Observable, take } from "rxjs";

import { AuthService } from "./auth.service";

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean | Observable<boolean> | Promise<boolean> {
      if(!!this.authService.user.value){

        return this.checkUserLogin(route)
      }else{
        this.router.navigate(['/'])
        return false;
      }
  }

  checkUserLogin(route: ActivatedRouteSnapshot): boolean {
    if (!!this.authService.user.value) {
      const userRole = this.authService.role;
      if (route.data["role"] && route.data["role"].indexOf(userRole) === -1) {
        this.router.navigate(['/home']);
        return false;
      }
      return true;
    }

    this.router.navigate(['/home']);
    return false;
  }
}
