import { NgModule } from '@angular/core';

import { AzureHttpClient } from './services/azure-http-client';
import { AzureToolkitService } from './services/azure-toolkit.service';
import { CognitiveService } from './services/cognitive.service';
import { UserService } from './services/user.service';

@NgModule({
    providers: [AzureHttpClient, AzureToolkitService, CognitiveService, UserService]
})
export class CommonModule { }
