import { NgModule } from '@angular/core';
import { AzureHttpClient } from './services/azureHttpClient';
import { CognitiveService } from './services/cognitive.service';
import { UserService } from './services/user.service';

@NgModule({
    providers: [AzureHttpClient, CognitiveService, UserService]
})
export class CommonModule { }
