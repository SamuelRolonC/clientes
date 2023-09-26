import React, { useState } from "react";
import './Customer.css';
import { useNavigate, useParams } from "react-router-dom";
import { useAppParameters } from "../Utils/useAppParameters";

function Customer() {
    const navigate = useNavigate();
    const [ formData, setFormData ] = useState({ name: '', surname: '', email: '', birthdate: '', cuit: '', address: '', phone: '' });
    const [ validation, setValidation ] = useState([]);
    const [ displayValidation, setDisplayValidation ] = useState('none');
    const { id } = useParams();
    const { getApiCustomerGetUrl, getApiCustomerPutPostUrl, getAppCustomerGridNavigate } = useAppParameters();
    
    // fetch data from API
    const getCustomerData = (id) => {
        fetch(getApiCustomerGetUrl(id), {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(response => response.json())
        .then(data => {
            console.log('Success');

            if (data.birthdate != null) {
                data.birthdate = data.birthdate.substring(0, 10);
            }

            setFormData(data);
        })
        .catch((error) => {
            console.error('Error:', error);
            alert('Error al obtener los datos.');
        });
    }

    React.useEffect(() => {
        if (id > 0) {
            getCustomerData(id);
        }
    }, [id]);

    const onSubmit = (e) => {
        e.preventDefault();
        console.log(id);
        console.log(formData);

        fetch(getApiCustomerPutPostUrl(), {
            method: id > 0 ? 'PUT' : 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                id: id,
                name: formData.name,
                surname: formData.surname,
                email: formData.email,
                birthdate: formData.birthdate,
                cuit: formData.cuit,
                address: formData.address,
                phone: formData.phone,
            }),
        })
        .then(response => response.json())
        .then(data => {
            if (data.id > 0) {
                console.log('Success');
                navigate(getAppCustomerGridNavigate());
            }
            else if (data.validation != null && data.validation.length > 0) {   
                console.log(data.validation);
                setValidation(data.validation);
                setDisplayValidation('inline-block');
            }
            else {
                console.log('Error: ', data);
                alert('Error al guardar los datos.');
            }
        })
        .catch((error) => {
            console.error('Error:', error);
            alert('Error al guardar los datos.');
        });
    }

    const onClickBack = () => {
        navigate(getAppCustomerGridNavigate());
    }

    const onChange = (event) => {
        const { name, value } = event.target;
        setFormData((prevFormData) => ({ ...prevFormData, [name]: value }));
    };

    return (
        <div className='Customer'>
            <h2>Cliente</h2>
            <div>
                <button type="button" onClick={onClickBack}>Volver</button>
            </div>
            <div>
                <ul id="validation-list" style={{display: displayValidation}}>
                    {validation.map((element, index) => (
                        <li key={index}>{element}</li>
                    ))}
                </ul>
            </div>
            <form onSubmit={onSubmit}>
                <div className="form-group">
                    <label>Nombre</label>
                    <input type="text" name="name" value={formData.name} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Apellido</label>
                    <input type="text" name="surname" value={formData.surname} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Email</label>
                    <input type="email" name="email" value={formData.email} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Fecha de nacimiento</label>
                    <input type="date" name="birthdate" value={formData.birthdate} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>CUIT</label>
                    <input type="number" name="cuit" value={formData.cuit} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Dirección</label>
                    <input type="text" name="address" value={formData.address} onChange={onChange} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Teléfono celular</label>
                    <input type="tel" name="phone" value={formData.phone} onChange={onChange} className="form-control" />
                </div>
                <button type="submit" className="button-primary">Guardar</button>
            </form>
        </div>
    );
}

export { Customer };