import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { LoginService } from './services/login.service';

describe('AuthGuard', () => {
  let authGuard: AuthGuard;
  let router: Router;
  let loginService: LoginService;
  let mockActivatedRouteSnapshot: ActivatedRouteSnapshot;
  let mockRouterStateSnapshot: RouterStateSnapshot;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      providers: [AuthGuard, LoginService]
    });

    authGuard = TestBed.inject(AuthGuard);
    router = TestBed.inject(Router);
    loginService = TestBed.inject(LoginService);
    mockActivatedRouteSnapshot = new ActivatedRouteSnapshot();
    mockRouterStateSnapshot = jasmine.createSpyObj<RouterStateSnapshot>('RouterStateSnapshot', ['toString']);
  });

  it('should allow access when the user is logged in', () => {
    spyOn(loginService, 'usuarioLogado').and.returnValue(true);

    const result = authGuard.canActivate(mockActivatedRouteSnapshot, mockRouterStateSnapshot);

    expect(result).toBeTruthy();
    expect(router.navigate).not.toHaveBeenCalled();
  });

  it('should redirect to login page when the user is not logged in', () => {
    spyOn(loginService, 'usuarioLogado').and.returnValue(false);
    spyOn(router, 'navigate');

    const result = authGuard.canActivate(mockActivatedRouteSnapshot, mockRouterStateSnapshot);

    expect(result).toBeFalsy();
    expect(router.navigate).toHaveBeenCalledWith(['/login']);
  });
});
