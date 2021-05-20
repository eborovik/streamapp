﻿import React, { useState } from 'react';
import { ButtonDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import { startRecording, stopRecording } from "../actions/Videos";

const LiveVideoOptions = (props) => {
    props = props
    const [dropdownOpen, setOpen] = useState(false);

    const toggle = () => setOpen(!dropdownOpen);

    const record = (props) => {
        startRecording(props.streamId)          
    }

    return (
        <ButtonDropdown isOpen={dropdownOpen} toggle={toggle}>
            <DropdownToggle caret>
                Button Dropdown
      </DropdownToggle>
            <DropdownMenu>
                <DropdownItem onClick={() => record(props)}>Start recording</DropdownItem>                
                <DropdownItem onClick={() => stopRecording(props.streamId)}>Stop recording</DropdownItem>                
            </DropdownMenu>
        </ButtonDropdown>
    );
}

export default LiveVideoOptions;