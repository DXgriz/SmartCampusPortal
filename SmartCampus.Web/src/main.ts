import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { appConfig } from './app/app.config';
import { RouterModule } from '@angular/router';
import { routes } from './app/app.routes';


const appConfigs = {
  providers: [],
  imports: [
    RouterModule.forRoot(routes),
  ],
};

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
