import React, { useState } from 'react';
import { ButtonDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

const SavedVideoOptions = (props) => {
    props = props
    const [dropdownOpen, setOpen] = useState(false);

    const toggle = () => setOpen(!dropdownOpen);

    const startRecording = (props) => console.log(props.name + 'wwwwwwwwwwwwwwwwwwwwww')

    return (
        <ButtonDropdown isOpen={dropdownOpen} toggle={toggle}>
            <DropdownToggle caret>
                Button Dropdown
      </DropdownToggle>
            <DropdownMenu>
                <DropdownItem onClick={() => startRecording(props)}>Edit</DropdownItem>
                <DropdownItem>Delete</DropdownItem>

            </DropdownMenu>
        </ButtonDropdown>
    );
}

export default SavedVideoOptions;
