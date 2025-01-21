const jsonObjectToFormData = (
    obj: Record<string, any>,
    formData = new FormData(),
    parentKey = ""
): FormData => {
    for (const key in obj) {
        if (obj.hasOwnProperty(key)) {
            const value = obj[key];
            const formKey = parentKey ? `${parentKey}.${key}` : key;

            if (value && typeof value === "object" && !(value instanceof File)) {
                jsonObjectToFormData(value, formData, formKey);
            } else if (value !== null && value !== undefined) {
                formData.append(formKey, value instanceof File ? value : String(value));
            }
        }
    }
    return formData;
}

export default jsonObjectToFormData;
