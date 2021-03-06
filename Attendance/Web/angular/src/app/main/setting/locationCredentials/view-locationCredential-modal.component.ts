﻿import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { GetLocationCredentialForViewDto, LocationCredentialDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewLocationCredentialModal',
    templateUrl: './view-locationCredential-modal.component.html'
})
export class ViewLocationCredentialModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetLocationCredentialForViewDto;


    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetLocationCredentialForViewDto();
        this.item.locationCredential = new LocationCredentialDto();
    }

    show(item: GetLocationCredentialForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
